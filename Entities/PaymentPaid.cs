using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTrackAPI.Entities
{
    public class PaymentPaid
    {
        [Key]
        public long PaymentPaidPID { get; set; }

        public long PeoplePID { get; set; }

        public long ChittiPID { get; set; }

        public double PaidAmount { get; set; }

        public DateTime Date { get; set; }

        public string Comments { get; set; }

        public long NotificationTypePID { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public long CreatedBy { get; set; }

        public long UpdatedBy { get; set; }
    }
}
