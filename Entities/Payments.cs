using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTrackAPI.Entities
{
    public class Payments
    {
        [Key]
        public long PaymentsPID { get; set; }

        public long PeoplePID { get; set; }

        public int Month { get; set; }

        public double Amount { get; set; }

        public long ChittiPID { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public long CreatedBy { get; set; }

        public long UpdatedBy { get; set; }
    }
}
