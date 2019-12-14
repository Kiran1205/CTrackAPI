using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTrackAPI.Entities
{
    public class People
    {
        [key]

        public long PeoplePID { get; set; }

        public string Name { get; set; }

        public long PhoneNumber { get; set; }

        public long ChittiPID { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public long CreatedBy { get; set; }

        public long UpdatedBy { get; set; }
    }
}
