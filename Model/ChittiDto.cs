using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTrackAPI.Model
{
    public class ChittiDto
    {
        
        public long ChittiPID { get; set; }

        public string Name { get; set; }

        public decimal Amount { get; set; }

        public int NoOfMonths { get; set; }

        public int PendingMonths { get; set; }

        public decimal PendingAmount { get; set; }

        public long RolePid { get; set; }

        public long CalledUserPID { get; set; }

        public DateTime EndDate { get; set; }
    }
}
