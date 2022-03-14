﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BLL.Services
{
  public  interface IDoctorService
    {
        Task<int> Add(DoctorViewModel doc);
        Task<int> Update(DoctorViewModel doc);
        Task<bool> Delete(DoctorViewModel doc);
            DoctorViewModel GetByID(int id);
            IEnumerable<DoctorViewModel> GetAll(int id , int ShiftId);
            IEnumerable<DoctorViewModel> GetAll();
    }
}
