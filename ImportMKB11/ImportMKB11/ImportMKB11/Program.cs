using ImportMKB11.Model;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;


namespace ImportMKB11
{
    class Program
    {
        private const int MODULE_ID = 26;

        private static List<string> acceptedXCode = new List<string>();

        private static List<ArtDocKssRow> ArtDocKssData = new List<ArtDocKssRow>();
        private static List<PubDocSetRow> PubDocSetData = new List<PubDocSetRow>();
        private static List<Diseases11Row> ArtDocIds = new List<Diseases11Row>();

        private static List<byte> Pubs = new List<byte>();

        private static Stopwatch Stopwatch = new Stopwatch();

        static void Main(string[] args)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Получили разрешенные XCode
            acceptedXCode = GetAcceptedXCodes();

            // Заполнили итоговые списки
            Run();
        }

        public static void Run()
        {
            try
            {
                using (ExcelPackage package = new ExcelPackage(DataService.File))
                {
                    DoTransaction(package.Workbook.Worksheets[0]);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DoTransaction(ExcelWorksheet worksheet)
        {
            using (SqlConnection connection = new SqlConnection(DataService.ConnectionString))
            {
                SqlBulkCopy sqlBulkCopy = null;
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText = Queries.SELECT_LAST_ID;
                        command.Parameters.Add(new SqlParameter("@module_id", MODULE_ID));

                        int? lastId = command.ExecuteScalar() == DBNull.Value ? null : Convert.ToInt32(command.ExecuteScalar());
                        if (!lastId.HasValue)
                        {
                            throw new Exception("Не удалось получить последний ID");
                        }

                        command.CommandText = Queries.SELECT_LAST_GROUP_ID;

                        int? lastGroupId = command.ExecuteScalar() == DBNull.Value ? null : Convert.ToInt32(command.ExecuteScalar());
                        if (!lastGroupId.HasValue)
                        {
                            throw new Exception("Не удалось получить последний Group ID");
                        }

                        command.CommandText = Queries.SELECT_ACCEPTED_PUBS;

                        using(IDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Pubs.Add(Convert.ToByte(reader["Pub_ID"]));
                            }
                        }

                        if (!Pubs.Any())
                        {
                            throw new Exception("Не удалось получить издания");
                        }

                        Stopwatch.Start();
                        FullLocalData(worksheet, lastId.Value, lastGroupId.Value);
                        Stopwatch.Stop();
                        Console.WriteLine($"Время получения данных FullLocalData {Stopwatch.ElapsedMilliseconds / 1000} c");

                        Stopwatch.Restart();
                        ExecuteBulkCopyIntoArtDocKss(sqlBulkCopy, connection, transaction);
                        Stopwatch.Stop();
                        Console.WriteLine($"Время получения данных ExecuteBulkCopyIntoArtDocKss {Stopwatch.ElapsedMilliseconds / 1000} c");

                        Stopwatch.Restart();
                        ExecuteBulkCopyIntoPubDocSet(sqlBulkCopy, connection, transaction);
                        Stopwatch.Stop();
                        Console.WriteLine($"Время получения данных ExecuteBulkCopyIntoPubDocSet {Stopwatch.ElapsedMilliseconds / 1000} c");

                        Stopwatch.Restart();
                        ExecuteBulkCopyIntoDiseases11(sqlBulkCopy, connection, transaction);
                        Stopwatch.Stop();
                        Console.WriteLine($"Время получения данных ExecuteBulkCopyIntoDiseases11 {Stopwatch.ElapsedMilliseconds / 1000} c");

                        Stopwatch.Restart();
                        ExecuteBulkCopyIntoDocGroup(sqlBulkCopy, connection, transaction);
                        Stopwatch.Stop();
                        Console.WriteLine($"Время получения данных ExecuteBulkCopyIntoPubDocSet {Stopwatch.ElapsedMilliseconds / 1000} c");

                        transaction.Commit();
                        Console.WriteLine("Данные добавлены в базу данных");
                    }
                } 
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    transaction.Rollback();
                }
                finally
                {
                    transaction.Dispose();
                    connection.Close();
                }
            }
        }

        private static void FullLocalData(ExcelWorksheet ws, int lastId, int lastGroupId)
        {
            int id = lastId;
            int groupId = lastGroupId;
            int rowCount = ws.Dimension.Rows;
            
            Dictionary<int, int> parents = new Dictionary<int, int>();

            for (int i = 2; i < rowCount; i++)
            {
                string code = DataService.GetCorrectedCode(ws.Cells[i, 4].Value?.ToString());

                if (string.IsNullOrEmpty(code) || code[0] == 'V' || (code[0] == 'X' && !acceptedXCode.Contains(code)))
                {
                    continue;
                }

                id += 1;
                groupId += 1;
                
                string title = DataService.GetCorrectedTitle(ws.Cells[i, 6].Value?.ToString(), out int pos);
                
                int? parentId = DataService.GetParentId(parents, pos);
                DataService.InsertParentId(parents, pos, id);

                string xmlContent = $"<propertiesxml><mkbProps MKB_CODE=\"{code}\" ACTUAL=\"1\" ID=\"{id}\" ID_PARENT=\"{parentId}\"/></propertiesxml>";

                string operInfo = "<operinfo><p>С 1 января 2022 года начинается внедрение МКБ-11 в клиническую практику. В переходном периоде можно использовать как код МКБ-10, так и <a class=\"doc\" num=\"1\" target=\"_self\" lnktype=\"intlnk\" title=\"\">код МКБ-11.</a> С 30 ноября 2022 года рекомендуем применять кодирование заболеваний по МКБ-11</p></operinfo>";

                ArtDocKssData.Add(new ArtDocKssRow(id, MODULE_ID, groupId, title, code, parentId, pos + 1, operInfo, xmlContent));

                foreach(byte pub in Pubs)
                {
                    PubDocSetData.Add(new PubDocSetRow(pub, id, MODULE_ID, groupId));
                }
            }

            ArtDocIds = ArtDocKssData.Select(s => new Diseases11Row() { Id = s.Id }).ToList();
        }

        private static void ExecuteBulkCopyIntoArtDocKss(SqlBulkCopy sqlBulkCopy, SqlConnection connection, SqlTransaction transaction)
        {
            string json = JsonConvert.SerializeObject(new { Table = ArtDocKssData });
            DataSet set = JsonConvert.DeserializeObject<DataSet>(json);

            using (sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction))
            {
                sqlBulkCopy.DestinationTableName = DataService.ArtDocKSSName; 

                sqlBulkCopy.ColumnMappings.Add("Id", "ID");
                sqlBulkCopy.ColumnMappings.Add("ModuleId", "ModuleID");
                sqlBulkCopy.ColumnMappings.Add("GroupId", "GroupID");
                sqlBulkCopy.ColumnMappings.Add("ParentId", "ParentID");
                sqlBulkCopy.ColumnMappings.Add("ParentModuleId", "ParentModuleID");
                sqlBulkCopy.ColumnMappings.Add("BegDate", "BegDate");
                sqlBulkCopy.ColumnMappings.Add("DocName", "DocName");
                sqlBulkCopy.ColumnMappings.Add("ShortName", "ShortName");
                sqlBulkCopy.ColumnMappings.Add("SortName", "SortName");
                sqlBulkCopy.ColumnMappings.Add("SortNum", "SortNum");
                sqlBulkCopy.ColumnMappings.Add("XmlContent", "XMLContent");
                sqlBulkCopy.ColumnMappings.Add("OperInfo", "OperInfo");
                sqlBulkCopy.ColumnMappings.Add("StateId", "StateID");

                sqlBulkCopy.WriteToServer(set.Tables[0]);
            }
        }

        private static void ExecuteBulkCopyIntoPubDocSet(SqlBulkCopy sqlBulkCopy, SqlConnection connection, SqlTransaction transaction)
        {
            string json = JsonConvert.SerializeObject(new { Table = PubDocSetData });
            DataSet set = JsonConvert.DeserializeObject<DataSet>(json);

            using (sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction))
            {
                sqlBulkCopy.DestinationTableName = DataService.PubDocSetName;

                sqlBulkCopy.ColumnMappings.Add("Id", "ID");
                sqlBulkCopy.ColumnMappings.Add("ModuleId", "ModuleID");
                sqlBulkCopy.ColumnMappings.Add("GroupId", "GroupID");
                sqlBulkCopy.ColumnMappings.Add("PubId", "Pub_ID");
                sqlBulkCopy.ColumnMappings.Add("ModifyDate", "ModifyDate");

                sqlBulkCopy.WriteToServer(set.Tables[0]);
            }
        }

        private static void ExecuteBulkCopyIntoDocGroup(SqlBulkCopy sqlBulkCopy, SqlConnection connection, SqlTransaction transaction)
        {

            string json = JsonConvert.SerializeObject(new { Table = ArtDocKssData.Select(s => new DocGroupRow() { GroupId = s.GroupId }).ToList() });
            DataSet set = JsonConvert.DeserializeObject<DataSet>(json);

            using (sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction))
            {
                sqlBulkCopy.DestinationTableName = DataService.DocGroupName;

                sqlBulkCopy.ColumnMappings.Add("GroupId", "GroupID");
                sqlBulkCopy.ColumnMappings.Add("GroupName", "GroupName");
                sqlBulkCopy.ColumnMappings.Add("Upd", "Upd");

                sqlBulkCopy.WriteToServer(set.Tables[0]);
            }
        }

        private static void ExecuteBulkCopyIntoDiseases11(SqlBulkCopy sqlBulkCopy, SqlConnection connection, SqlTransaction transaction)
        {
            string json = JsonConvert.SerializeObject(new { Table = ArtDocIds });
            DataSet set = JsonConvert.DeserializeObject<DataSet>(json);

            using (sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction))
            {
                sqlBulkCopy.DestinationTableName = DataService.Diseases11Name;

                sqlBulkCopy.ColumnMappings.Add("Id", "Id");

                sqlBulkCopy.WriteToServer(set.Tables[0]);
            }
        }

        private static List<string> GetAcceptedXCodes()
        {
            List<string> result = new List<string>();
            try
            {
                using (ExcelPackage package = new ExcelPackage(DataService.FileXCodes))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;

                    for(int i = 2; i < rowCount; i++)
                    {
                        result.Add(worksheet.Cells[i, 7].Value?.ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

    }
}
