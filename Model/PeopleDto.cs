using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTrackAPI.Model
{
    public class PeopleDto
    {
        public string Name { get; set; }

        public long PhoneNumber { get; set; }

        public double PendingAmount { get; set; }

        public long ChittiPID { get; set; }

        public long PeoplePID { get; set; }

    }
}
