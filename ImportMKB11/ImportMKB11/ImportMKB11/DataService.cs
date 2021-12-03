using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;


namespace ImportMKB11
{
    public class DataService
    {
        public static readonly FileInfo File = new FileInfo(@"C:\Users\evgen\Downloads\SimpleTabulation.xlsx");

        public static readonly FileInfo FileXCodes = new FileInfo(@"C:\Users\evgen\Downloads\AcceptedCodeХ.xlsx");

        public const string ConnectionString = "Data Source=index01.sps.prod.cloud2.amedia.tech;Initial Catalog=KLM_2;User Id=evfilippov;PASSWORD=Fev0110;";

        public const string PubDocSetName = "dbo.TestPubDocSet";
        public const string ArtDocKSSName = "dbo.TestArtDocKSS";
        public const string DocGroupName = "dbo.TestDocGroup";
        public const string Diseases11Name = "dbo.TestDiseases11";

        private static readonly Regex rgx = new Regex(@"BlockL[\d]+[-]{1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static string GetCorrectedCode(string code)
        {
            return string.IsNullOrEmpty(code) ? code : rgx.Replace(code, string.Empty);
        }

        public static string GetCorrectedTitle(string str, out int pos)
        {
            string result = str;
            pos = 0;
            if (!string.IsNullOrEmpty(result))
            {
                while (result.Substring(0, 2) == "- ")
                {
                    pos += 1;
                    result = result.Remove(0, 2);
                }
            }

            return result;
        }

        public static int? GetParentId(Dictionary<int, int> parents, int pos)
        {
            if (parents.ContainsKey(pos - 1))
            {
                return parents[pos - 1];
            }

            return null;
        }

        public static void InsertParentId(Dictionary<int, int> parents, int pos, int currentId)
        {
            if (!parents.ContainsKey(pos))
            {
                parents.Add(pos, currentId);
            }
            else
            {
                parents[pos] = currentId;
            }
        }
    }
}
