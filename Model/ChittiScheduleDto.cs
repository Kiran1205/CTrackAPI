using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTrackAPI.Model
{
    public class ChittiScheduleDto
    {
        public DateTime Month { get; set; }

        public string Name { get; set; }

        public string MonthName { get; set; }

        public decimal Amount { get; set; }

        public decimal BaseAmount { get; set; }

        public decimal AuctionAmount { get; set; }

        public decimal PersonAmount { get; set; }

        public bool Completed { get; set; }
    }
}
