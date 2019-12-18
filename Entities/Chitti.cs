using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTrackAPI.Entities
{
    public class Chitti
    {
        [Key]
        public long ChittiPID { get; set; }

        public string Name { get; set; }

        public decimal Amount { get; set; }

        public decimal Commission { get; set; }

        public int NoOfMonths { get; set; }        

        public DateTime StartDate { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public long CreatedBy { get; set; }

        public long UpdatedBy { get; set; }
    }
}
