﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Index(nameof(SSN), IsUnique = true)]
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
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Whatsapp { get; set; }
        public DateTime LogInTime { get; set; }
        public bool IsActive { get; set; }
        public string Work { get; set; }
        public string maritalStatus { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual IdentityUser User { get; set; }

    }
}
