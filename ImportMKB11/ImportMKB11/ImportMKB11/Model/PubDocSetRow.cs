using System;

namespace ImportMKB11.Model
{
    public class PubDocSetRow
    {
        public PubDocSetRow()
        {

        }

        public PubDocSetRow(byte pubId, int id, byte moduleId, int groupId)
        {
            PubId = pubId;
            Id = id;
            ModuleId = moduleId;
            GroupId = groupId;
            
        }

        public byte PubId { get; set; }
        public int Id { get; set; }
        public byte ModuleId { get; set; }
        public int GroupId { get; set; }
        public DateTime ModifyDate { get { return DateTime.Now; } }
    }
}
