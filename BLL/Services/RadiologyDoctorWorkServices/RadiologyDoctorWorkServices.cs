﻿using BLL.Helper;
using DAL.Database;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.RadiologyDoctorWorkServices
{
    public class RadiologyDoctorWorkServices : IRadiologyDoctorWorkServices
    {
        private readonly AplicationDbContext context;

        public RadiologyDoctorWorkServices(AplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> AddResult(RadiologyDoctorWorkViewModel model)
        {
            var OldData = context.PatientRediology.Where(x => x.Id == model.PatientRadiologyId).Select(x => x).FirstOrDefault();
            if (model.PhotoUrl != null)
            {
                OldData.Photo = UploadFileHelper.SaveFile(model.PhotoUrl, "RadiologyResults/Photos");

            }
            if (model.DocumentUrl != null)
            {
                OldData.Document = UploadFileHelper.SaveFile(model.DocumentUrl, "RadiologyResults/Documents");
            }
            if (OldData.Photo != null || OldData.Document != null)
            {
                OldData.State = true;
            }
            OldData.DoneDateAndTime = DateTime.Now;
            int result = await context.SaveChangesAsync();
            return result;
        }

        public IEnumerable<RadiologyDoctorWorkViewModel> GetAllOrders()
        {
            var Data = context.PatientRediology.Select(x => x);
            List<RadiologyDoctorWorkViewModel> DataOfWaiting = new List<RadiologyDoctorWorkViewModel>();
            foreach (var item in Data)
            {
                if (item.State == false)
                {
                    RadiologyDoctorWorkViewModel obj = new RadiologyDoctorWorkViewModel();
                    obj.RadiologyName = context.Radiology.Where(x => x.Id == item.RadiologyId).Select(x => x.Name).FirstOrDefault();
                    var PatientId = context.DailyDetection.Where(x => x.Id == item.DailyDetectionId).Select(x => x.PatientId).FirstOrDefault();
                    obj.PatientName = context.Patients.Where(x => x.Id == PatientId).Select(x => x.Name).FirstOrDefault();
                    var DoctorId = context.DailyDetection.Where(x => x.Id == item.DailyDetectionId).Select(x => x.DoctorId).FirstOrDefault();
                    obj.DoctorName = context.Doctors.Where(x => x.Id == DoctorId).Select(x => x.Name).FirstOrDefault();
                    obj.PatientRadiologyId = item.Id;
                    obj.DateAndTime = item.OrderDateAndTime;
                    DataOfWaiting.Add(obj);
                }               
            }
            return DataOfWaiting;
        }

        public RadiologyDoctorWorkViewModel GetByID(int id)
        {
            var PatientRadiology = context.PatientRediology.Where(x => x.Id == id).Select(x => x).FirstOrDefault();
            var DailyDetectionId = PatientRadiology.DailyDetectionId;
            var PatientId = context.DailyDetection.Where(x => x.Id == DailyDetectionId).Select(x => x.PatientId).FirstOrDefault();
            var PatientData = context.Patients.Where(x => x.Id == PatientId).Select(x => x).FirstOrDefault();
            var DoctorId = context.DailyDetection.Where(x => x.Id == DailyDetectionId).Select(x => x.DoctorId).FirstOrDefault();
            var DoctorName = context.Doctors.Where(x => x.Id == DoctorId).Select(x => x.Name).FirstOrDefault();
            RadiologyDoctorWorkViewModel obj = new RadiologyDoctorWorkViewModel();
            obj.PatientName = PatientData.Name;
            obj.SSN = PatientData.SSN;
            obj.Address = PatientData.Address;
            obj.Phone = PatientData.Phone;
            obj.DoctorName = DoctorName;
            return obj;
        }
    }
}