﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CTrackAPI.Entities
{
    public class Roles
    {
        [Key]
        public long RolesPID { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public long CreatedBy { get; set; }

        public long UpdatedBy { get; set; }
    }
}
