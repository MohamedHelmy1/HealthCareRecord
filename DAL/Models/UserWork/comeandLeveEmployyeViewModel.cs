﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DAL.Models.UserWork
{
    public class comeandLeveEmployyeViewModel
    {
        public int ID { get; set; }
        string UserId { get; set; }
       
        public DateTime come { get; set; }
        public DateTime Leave { get; set; }
        public double comeLate { get; set; }
        public double LeaveEaley { get; set; }
    }
}
