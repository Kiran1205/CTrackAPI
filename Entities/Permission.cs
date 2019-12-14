using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTrackAPI.Entities
{
    public class Permission
    {
        [key]

        public long PermissionPID { get; set; }

        public long ChittiPID { get; set; }

        public long UserPID { get; set; }

        public long RolePID { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public long CreatedBy { get; set; }

        public long UpdatedBy { get; set; }
    }
}
