using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTrackAPI.Entities
{
    public class NotificationType
    {
        [key]

        public long NotificationTypePID { get; set; }

        public string Type { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public long CreatedBy { get; set; }

        public long UpdatedBy { get; set; }
    }
}
