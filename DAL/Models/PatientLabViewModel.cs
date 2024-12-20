﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class PatientLabViewModel
    {
        public int Id { get; set; }
        public string Document { get; set; }
        public string Photo { get; set; }
        public bool State { get; set; }
        public bool Cancel { get; set; }
        public DateTime DateAndTime { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        public int? DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        public int? LabId { get; set; }
        [ForeignKey("LabId")]
        public Lab Lab { get; set; }
        public string DoctorName { get; set; }
        public string LapName { get; set; }
        public string DoctorNameorder { get; set; }
        public string DoctorNamework { get; set; }
        public int? DailyDetectionId { get; set; }
    }
}
