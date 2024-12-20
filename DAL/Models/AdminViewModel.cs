﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class AdminViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Whatsapp { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid EMail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [MinLength(6, ErrorMessage = "Min Len 6 Characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is Required")]
        [MinLength(6, ErrorMessage = "Min Len 6 Characters")]
        [Compare("Password", ErrorMessage = "Password Not Match")]
        public string ConfirmPassword { get; set; }
    }
}
