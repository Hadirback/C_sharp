using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportMKB11
{
    public class Queries
    {
        public const string SELECT_LAST_ID = @"
SELECT TOP 1 ID FROM dbo.ArtDocKSS WHERE ModuleID = @module_id ORDER BY ID DESC";

        public const string SELECT_LAST_GROUP_ID = @"
SELECT TOP 1 GroupID FROM DocGroup ORDER BY GroupID DESC";

        public const string SELECT_ACCEPTED_PUBS = @"
SELECT Pub_ID FROM Pub WHERE SysID = 34";
    }
}
