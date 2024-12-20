﻿using DAL.Entities.EmployeePayment;
using DAL.Entities.UserWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Index(nameof(SSN), IsUnique = true)]
    public class Emplyee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SSN { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Whatsapp { get; set; }
        public int? VacationBalance { get; set; }

        public bool IsActive { get; set; }
        public DateTime WorkStartTime { get; set; }
        public string Photo { get; set; }
        public int? ShiftId { get; set; }
        [ForeignKey("ShiftId")]
        public Shift Shift { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual IdentityUser User { get; set; }
        public double Salary { get; set; }
        public double ShiftPrise { get; set; }
        public int Fk_PaymentId { get; set; }
        public PaymentWay paymentWay { get; set; }
        public int TypeWorkId { get; set; }
        [ForeignKey("TypeWorkId")]
        public TypeWork TypeWork { get; set; }

    }
}
