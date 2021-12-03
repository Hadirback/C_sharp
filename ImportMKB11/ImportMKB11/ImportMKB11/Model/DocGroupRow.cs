using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportMKB11.Model
{
    public class DocGroupRow
    {
        public int GroupId { get; set; }
        public string GroupName { get { return string.Empty; }  }
        public short Upd { get { return 1; } }
    }
}
