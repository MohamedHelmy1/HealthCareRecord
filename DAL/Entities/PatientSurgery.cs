﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class PatientSurgery
    {
        public int Id { get; set; }
        public bool State { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public int? PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        public int? DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        public int? NurseId { get; set; }
        [ForeignKey("NurseId")]
        public Nurse Nurse { get; set; }
        public int? SurgeryId { get; set; }
        [ForeignKey("SurgeryId")]
        public Surgery Surgery { get; set; }
        public int? DailyDetectionId { get; set; }
        [ForeignKey("DailyDetectionId")]
        public DailyDetection DailyDetection { get; set; }
    }
}
