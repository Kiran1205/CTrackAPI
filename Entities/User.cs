using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CTrackAPI.Entities
{
    public class User
    {
        [Key]
        public long UserPID { get; set; }

        public string Name { get; set; }

        public long PhoneNumber { get; set; }

        public string Password { get; set; }

        public long PinNumber { get; set; }

        public string DeviseInfo { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public long CreatedBy { get; set; }

        public long UpdatedBy { get; set; }

    }
}
