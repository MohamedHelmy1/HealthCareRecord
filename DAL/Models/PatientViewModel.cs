﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Index(nameof(SSN), IsUnique = true)]
    public  class PatientViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "SSN is Required")]
        [MinLength(14, ErrorMessage = "SSN Must Be 14 Number This is less than 14")]
        [MaxLength(14, ErrorMessage = "SSN Must Be 14 Number This is more than 14")]
        [Remote(action: "SSNUssed", controller: "Patient")]
        public string SSN { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "BirthDate Is Required")]
        [DataType(DataType.DateTime)]
        [CustomHireDate(ErrorMessage = "Enter Real Birth Date")]

        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Gender is Required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Phone is Required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Another Phone is Required")]
        public string AnotherPhone { get; set; }
        public bool IsActive { get; set; }
        public string photo { get; set; }
        //[RegularExpression(@"(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$", ErrorMessage = "Only Image files allowed.")]
        public IFormFile PhotoUrl { get; set; }
        public DateTime LogInTime { get; set; }
        public string UserId { get; set; }

        
        [EmailAddress(ErrorMessage = "Invalid EMail")]
        [Remote(action: "VerifyEmail", controller: "Users")]
        public string Email { get; set; }

        [MinLength(6, ErrorMessage = "Min Len 6 Characters")]
        public string Password { get; set; }

        
        [MinLength(6, ErrorMessage = "Min Len 6 Characters")]
        [Compare("Password", ErrorMessage = "Password Not Match")]
        public string ConfirmPassword { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Whatsapp { get; set; }
        [Required(ErrorMessage = "Work is Required")]
        public string Work { get; set; }
        [Required(ErrorMessage = "Marital Status is Required")]
        public string maritalStatus { get; set; }
        public class CustomHireDate : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                DateTime dateTime = Convert.ToDateTime(value);
                return dateTime <= DateTime.Now;
            }
        }
    }
}
