﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Services.NerseServices
{
    public interface INurseServices
    {
        Task<int> Add(NurseViewModel Nurse);
        Task<int> UpdateAccountInfo(NurseViewModel Nurse);
        Task<int> UpdateBasicInfo(NurseViewModel Nurse);

        Task<bool> Delete(int id);
        IEnumerable<NurseViewModel> GetAll();
        Task<NurseViewModel> GetByID(int id);
        bool SSNUnUsed(string ssn);


    }
}
