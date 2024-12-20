﻿using AutoMapper;
using DAL.Entities;
using DAL.Entities.vacation;
using DAL.Models;
using DAL.Models.vacation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Patient, PatientViewModel>();
            CreateMap<PatientViewModel, Patient>();
            //Repologey
            CreateMap<Radiology, RadiologyViewModel>();
            CreateMap<RadiologyViewModel, Radiology>();
            //Medicine
            CreateMap<Medicine, MedicineViewModel>();
            CreateMap<MedicineViewModel, Medicine>();
            //Lab
            CreateMap<Lab, LabViewModel>();
            CreateMap<LabViewModel, Lab>();
            //patiantDoctor
            CreateMap<DailyDetectionViewModel, DailyDetection>();
            CreateMap<DailyDetection, DailyDetectionViewModel>();
            // Vacation
            CreateMap<VacationTypeViewModel, VacationType>().ReverseMap();
            CreateMap<VacationPlainViewModel, vacationPlan>().ReverseMap();
            CreateMap<RequestVacationViewModel, RequestVacation>().ReverseMap();



        }
    }
}
 