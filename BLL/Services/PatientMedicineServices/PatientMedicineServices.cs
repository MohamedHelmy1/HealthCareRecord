﻿using DAL.Database;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.PatientMedicineServices
{
   
    public class PatientMedicineServices : IPatientMedicineServices
    {
        private readonly AplicationDbContext context;
        public PatientMedicineServices(AplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<PatientMedicineViewModel> GetAll(int id)
        {
            try
            {
                return context.PatientMedicine
                                .Where(x => x.State == true && x.PatientId == id)
                                       .Select(x => new PatientMedicineViewModel
                                       {
                                           Id = x.Id,
                                           PatientId = x.PatientId,
                                           DoctorId = x.DoctorId,
                                           MedicineName = context.Medicine.Where(y => y.Id == x.MedicineId).Select(y => y.Name).FirstOrDefault(),
                                           DateAndTime = x.DateAndTime,
                                           
                                       }); ;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}