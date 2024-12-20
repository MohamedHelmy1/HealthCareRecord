using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Database;
using BLL.Services;
using BLL.Services.PatientServices;
using BLL.Mapper;
using BLL.Services.EmplyeeServices;
using BLL.Services.ReservationServices;
using BLL.Services.DepartmentServices;
using BLL.Services.UsersServices;
using BLL.Services.RolesServices;
using BLL.Services.NerseServices;
using BLL.Services.shiftServeses;
using BLL.Services.RoomServices;
using BLL.Services.RepologeyServices;
using BLL.Services.MedicineServices;
using BLL.Services.LabServices;
using BLL.Services.DoctorWork.DoctorPatiant;
using BLL.Services.PatientLabServices;
using BLL.Services.PatientRediologyServices;
using BLL.Services.PatientRoomServices;
using BLL.Services.PatientSurgeryServices;
using BLL.Services.PatientMedicineServices;
using BLL.Services.SurgeryServices;
using BLL.Services.LabDoctorWorkServices;
using BLL.Services.RadiologyDoctorWorkServices;
using BLL.Services.PharmacistWorkServices;
using BLL.Services.RoomWorkServices;
using BLL.Services.SurgeryDoctorServices;
using UI.Hubs;
using BLL.Services.NotificationsServices;
using BLL.Services.StatisticServices;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using BLL.Services.TreatmentServices;
using BLL.Services._1Vacation.VacationServices.RequestVacationSevice;
using BLL.Services._1Vacation.VacationServices.VacationServices;
using BLL.Services._1Vacation.VacationServices.VacationTypeSevice;
using BLL.Services._1Vacation.VacationServices;
using BLL.Services._1Vacation.VacationServices.UserVacation;
using BLL.Services.EmployeePayment.TypeWork;
using BLL.Services.EmployeePayment.PaymentWay;

namespace UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            

            //To Get Connection string
            services.AddDbContextPool<AplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<AplicationDbContext>();
            services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
        .AddDataAnnotationsLocalization();
           
            // To Add Identity Tables (Users - Roles - ...)
            services.AddIdentity<IdentityUser, IdentityRole>(options => {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 0; 
            }).AddEntityFrameworkStores<AplicationDbContext>()
        .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);

            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientServices, PatientServices>();
            services.AddScoped<IEmplyeeServices, EmplyeeServices>();
            services.AddScoped<IReservationServices, ReservationServices>();
            services.AddScoped<IDepartmentSevice, DepartmentService>();
            services.AddScoped<IUsersServices, UsersServices>();
            services.AddScoped<IRolesServices, RolesServices>();
            services.AddScoped<INurseServices, NurseServices>();
            services.AddScoped<IShiftServeses, ShiftServices>();
            services.AddScoped<IRoomServices, RoomServices>();
            services.AddScoped<IRepologeyServices, RepologeyServices>();
            services.AddScoped<IMedicineServices, MedicineServices>();
            services.AddScoped<ILabServices, LabServices>();
            services.AddScoped<IPatiantDoctor, PatiantDoctor>();
            services.AddScoped<IPatientLabServices, PatientLabServices>();
            services.AddScoped<IPatientMedicineServices, PatientMedicineServices>();
            services.AddScoped<IPatientRediologyServices, PatientRediologyServices>();
            services.AddScoped<IPatientRoomServices, PatientRoomServices>();
            services.AddScoped<IPatientSurgeryServices, PatientSurgeryServices>();
            services.AddScoped<ISurgeryServices, SurgeryServices>();
            services.AddScoped<ILabDoctorWorkServices, LabDoctorWorkServices>();
            services.AddScoped<IRadiologyDoctorWorkServices, RadiologyDoctorWorkServices>();
            services.AddScoped<IRoomWorkServices, RoomWorkServices>();
            services.AddScoped<ISurgeryDoctorServices, SurgeryDoctorServices>();
            services.AddScoped<IPharmacistWorkServices, PharmacistWorkServices>(); 
            services.AddScoped<INotificationsServices, NotificationsServices>();
            services.AddScoped<ITreatmentServices, TreatmentServices>();
            services.AddScoped<IStatisticServices, StatisticServices>();
            //Vaction
            services.AddScoped<IRequestVacationSevice, RequestVacationSevice>();
            services.AddScoped<IVacationServices, VacationPlainSevice>();
            services.AddScoped<IVacationTypeSevice, VacationtypeSevice>();
            services.AddScoped<IUserVacation, UserVacation>();
            services.AddScoped<ITypeWorkService, TypeWorkService>();
            services.AddScoped<IPaymentWayService, PaymentWayService>();









            //AutoMapper


            services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

            //signalr
            services.AddSignalR();
            //Loclization
            services.AddLocalization(op =>
            {
                op.ResourcesPath = "Resources";
            }); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
           
            app.UseAuthentication();
            app.UseAuthorization();
            //Localization
            var supportedCultures = new[] {
                  new CultureInfo("ar-SA"),
                  new CultureInfo("en-US"),
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = new List<IRequestCultureProvider>
                {
                new QueryStringRequestCultureProvider(),
                new CookieRequestCultureProvider()
                }
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=HCRWebsite}/{action=Home}/{id?}");
                endpoints.MapHub<RealtimeHub>("/Realtime");
            });
            //Report
            Rotativa.AspNetCore.RotativaConfiguration.Setup(env.WebRootPath);
        }
    }
}
