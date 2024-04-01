using AppointmentSystem.UI.Application.Mappings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllersWithViews();
services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.Cookie.Name = "AppointmentCookie";
        opt.Cookie.HttpOnly = true;
        opt.Cookie.SameSite = SameSiteMode.Strict;
        opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        opt.ExpireTimeSpan = TimeSpan.FromDays(1);
        opt.LoginPath = "/Auth/PatientLogin";
        opt.LogoutPath = "/Auth/LogOut";

    });
services.AddAutoMapper(opt =>
{
    new PoliclinicProfile();
    new DoctorUserProfile();
    new AppointmentProfile();
});

var app = builder.Build();

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "route",
    pattern: "{controller=Appointment}/{action=List}/{id?}"
    );

app.Run();
