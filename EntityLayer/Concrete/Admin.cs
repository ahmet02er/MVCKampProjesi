﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [StringLength(50)]
        public string AdminUsername { get; set; }

        [StringLength(100)]
        public string AdminPassword { get; set; }

        public string AdminRole { get; set; }
        public bool AdminStatus { get; set; }
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }


    }
}
