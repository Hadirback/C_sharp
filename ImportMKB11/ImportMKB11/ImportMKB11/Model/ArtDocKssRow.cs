using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportMKB11.Model
{
    public class ArtDocKssRow
    {
        public ArtDocKssRow()
        {

        }

        public ArtDocKssRow(int id, byte moduleId, int groupId, string docName, string shortName,
            int? parentId, int sortNum, string operInfo, string xmlContent)
        {
            Id = id;
            ModuleId = moduleId;
            GroupId = groupId;
            DocName = docName;
            ShortName = shortName;
            ParentId = parentId;
            SortNum = sortNum;
            OperInfo = operInfo;
            XmlContent = xmlContent;
        }

        public int Id { get; set; }
        public byte ModuleId { get; set; }
        public int GroupId { get; set; }
        public int? ParentId { get; set; }
        public byte ParentModuleId { get { return ModuleId; } }
        public DateTime BegDate { get { return new DateTime(2022, 01, 01); } }
        public string DocName { get; set; }
        public string ShortName { get; set; }
        public string SortName { get { return $"{ShortName} {DocName}"; } }
        public int SortNum { get; set; }
        public string XmlContent { get; set; }
        public string OperInfo { get; set; }
    }
}
