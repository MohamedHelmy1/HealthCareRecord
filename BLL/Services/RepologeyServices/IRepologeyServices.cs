﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.RepologeyServices
{
    public interface IRepologeyServices
    {
        bool Add(RadiologyViewModel Repologey);
        bool Update(RadiologyViewModel Repologey);

        bool Delete(int id);
        bool UpdateDelete(int id);
        decimal GetSalery(string name);
        IEnumerable<RadiologyViewModel> GetAll();
        IEnumerable<RadiologyViewModel> GetAllDeletd();


        RadiologyViewModel GetByID(int id);
    }
}
