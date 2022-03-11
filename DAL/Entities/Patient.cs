﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public class Patient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SSN { get; set; }

        public string Address { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }

        public string AnotherPhone { get; set; }

        public string photo { get; set; }

        public DateTime LogInTime { get; set; }

        public DateTime LogOutTime { get; set; }


        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual IdentityUser User { get; set; }

    }
}