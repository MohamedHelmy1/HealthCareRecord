﻿using BLL.Helper;
using BLL.Services.UsersServices;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ILogger<AccountController> logger;
        private readonly IUsersServices users;

        public AccountController(UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager, ILogger<AccountController> logger, IUsersServices users)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.users = users;
        }
        public IActionResult Registration()
        {
            return View();
        }

        #region Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var AllUsers = users.GetAll();
            if(AllUsers == null)
            {
                var user = new IdentityUser()
                {
                    Email = "admin@gmail.com",
                    UserName = "admin@gmail.com",
                };
                string password = "123456";
                var result = await userManager.CreateAsync(user, password);
                ModelState.AddModelError("", "Use This Account => Email : admin@gmail.com, Password : 123456");
                return View();
            }
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByEmailAsync(model.Email);
                    
                    if (user != null)
                    {
                        var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                        if (result.Succeeded)
                        {
                            //get User Role By Email
                            var UserEmail = await userManager.FindByEmailAsync(model.Email);
                            var UserRole = await userManager.GetRolesAsync(UserEmail);
                            if (UserRole[0] == "Admin")
                            {
                                return RedirectToAction("Index", "Admin");
                            }
                            else if (UserRole[0] == "Receptionist")
                            {

                                return RedirectToAction("Create", "Patient");
                            }
                            else if (UserRole[0]=="Doctor")
                            {

                                return RedirectToAction("MyPatiants", "DoctorPages");
                            }
                            else if (UserRole[0] == "AnalysisDoctor")
                            {

                                return RedirectToAction("WaitingPage", "LabDoctor");
                            }
                            else if (UserRole[0] == "RadiologyDoctor")
                            {

                                return RedirectToAction("WaitingPage", "RadiologyDoctor");
                            }
                            else if (UserRole[0] == "Pharmacist")
                            {

                                return RedirectToAction("WaitingPage", "Pharmacist");
                            }
                            else
                            {
                                return RedirectToAction("Login", "Account");

                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Email Or Password InCorrect");
                            return View(model);
                        }
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }
        #endregion


        #region LogOff (Sign Out)

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        #endregion

        #region Forget Password

        public IActionResult ForgetPassword()
        {
            return View();
        }

        public IActionResult ConfirmForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByEmailAsync(model.Email);

                    if (user != null)
                    {
                        // Generate Token
                        var token = await userManager.GeneratePasswordResetTokenAsync(user);

                        // Get Reset Password Link
                        var passwordResetLink = Url.Action("ResetPassword", "Account", new { Email = model.Email, Token = token }, Request.Scheme);

                        MailSender.SendMail(new MailViewModel()
                        {

                            Email = model.Email,
                            Title = "Reset Password",
                            Message = passwordResetLink
                        });

                        return RedirectToAction("ConfirmForgetPassword");
                    }
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }

        }

        #endregion

        #region Reset Password

        public IActionResult ResetPassword(string Email, string Token)
        {
            if (Email != null && Token != null)
            {
                return View();
            }

            return RedirectToAction("Login");
        }

        public IActionResult ConfirmResetPassword()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    var user = await userManager.FindByEmailAsync(model.Email);

                    if (user != null)
                    {
                        var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);

                        if (result.Succeeded)
                        {
                            return RedirectToAction("ConfirmResetPassword");
                        }

                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }

                    return RedirectToAction("Registration");


                }

                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }

        }

        #endregion

    }
}
