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

        public double Amount { get; set; }

        public int NoOfMonths { get; set; }

        public int PendingMonths { get; set; }

        public double PendingAmount { get; set; }

        public int RolePid { get; set; }
    }
}
