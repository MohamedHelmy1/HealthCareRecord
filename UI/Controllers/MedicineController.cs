﻿using BLL.Services.MedicineServices;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class MedicineController : Controller
    {
        private readonly IMedicineServices medicine;

        public MedicineController(IMedicineServices medicine)
        {
            this.medicine = medicine;
        }
        public IActionResult AddRepologey()
        {
            ViewBag.Medicine = "";
            return View();
        }
        [HttpPost]
        public IActionResult AddMedicine(MedicineViewModel Rad)
        {
            var data = medicine.Add(Rad);
            if (data == true)
            {
                ViewBag.Medicine = "true";
                return View();

            }
            else
            {
                ViewBag.Medicine = "1";
                return View(Rad);

            }
        }
        public IActionResult UpdateMedicine(int id)
        {

            var data = medicine.GetByID(id);
            ViewBag.Medicine = "";
            return View(data);
        }
        [HttpPost]
        public IActionResult UpdateMedicine(MedicineViewModel med)
        {

            var data = medicine.Update(med);
            if (data == true)
            {
                return RedirectToAction("ViewAllRepologey");

            }
            else
            {
                ViewBag.Medicine = "Please Change the medicine Name  it Used befoer";
                return View(med);
            }

        }
        public IActionResult ViewAllMedicine()
        {
            var data = medicine.GetAll();
            return View(data);

        }
        public IActionResult ViewEndMedicine()
        {
            var data = medicine.GetAllEnd();
            return View(data);

        }
       
       
    }
}
