﻿using BLL.Services.shiftServeses;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ShiftController : Controller
    {
        private readonly IShiftServeses shift;

        public ShiftController(IShiftServeses shift)
        {
            this.shift = shift;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ShiftViewModel shifts)
        {
            if (ModelState.IsValid)
            {
                shift.Add(shifts);
                ViewBag.Success = 1;
            }
             

            return View();
        }
        public IActionResult Update(int id)
        {

            var data = shift.GetByID(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Update(ShiftViewModel shifts)
        {
            if (ModelState.IsValid)
            {
                shift.Update(shifts);
                ViewBag.Success = 1;

            }

            return View(shifts);
        }
        public IActionResult GetAll()
        {
            var data=shift.GetAll();
            return View(data);
        }
        public JsonResult Delete(int id)
        {

            var data = shift.Delete(id);
           
            return Json(data);

        }

    }
}
