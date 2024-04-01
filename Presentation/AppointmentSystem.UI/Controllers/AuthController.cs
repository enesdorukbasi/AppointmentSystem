using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.Cookies;
using AppointmentSystem.UI.Application.DTOs;
using AppointmentSystem.UI.Domain.Models;
using AppointmentSystem.UI.Domain.Constants;
using Microsoft.AspNetCore.Authorization;

namespace AppointmentSystem.UI.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DoctorLogin()
        {
            return View(new LoginDTO());
        }
        [HttpPost]
        public async Task<IActionResult> DoctorLogin(LoginDTO dto)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync(ApiConstants.apiBaseUrl + "DoctorUser/LoginDoctor", content);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var loginModel = JsonSerializer.Deserialize<IDTO<DoctorUser>>(jsonResponse, new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });
                        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                        var token = handler.ReadJwtToken(loginModel?.data?.Token);
                        var claims = token.Claims.ToList();
                        if (loginModel != null)
                        {
                            claims.Add(new Claim("token", loginModel?.data?.Token ?? ""));
                            claims.Add(new Claim("fullName", string.IsNullOrEmpty(loginModel?.data?.Card) ? loginModel!.data!.FullName : loginModel!.data!.Card));
                            claims.Add(new Claim("jsonUser", jsonResponse));
                            var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                            var authProps = new AuthenticationProperties
                            {
                                ExpiresUtc = loginModel?.data?.TokenExpireDate,
                                IsPersistent = true
                            };
                            await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                            return RedirectToAction("ListDoctor", "Appointment");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"API isteği başarısız: {response.StatusCode}");
                    }
                }
                catch (Exception)
                {

                }
            }
            return View();
        }

        public IActionResult PatientLogin()
        {
            return View(new LoginDTO());
        }
        [HttpPost]
        public async Task<IActionResult> PatientLogin(LoginDTO dto)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync(ApiConstants.apiBaseUrl + "PatientUser/LoginPatient", content);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var loginModel = JsonSerializer.Deserialize<IDTO<PatientUser>>(jsonResponse, new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });
                        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                        var token = handler.ReadJwtToken(loginModel?.data?.Token);
                        var claims = token.Claims.ToList();
                        if (loginModel != null)
                        {
                            claims.Add(new Claim("token", loginModel?.data?.Token ?? ""));
                            claims.Add(new Claim("fullName", loginModel?.data?.FullName ?? ""));
                            claims.Add(new Claim("jsonUser", jsonResponse));
                            var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                            var authProps = new AuthenticationProperties
                            {
                                ExpiresUtc = loginModel?.data?.TokenExpireDate,
                                IsPersistent = true
                            };
                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                            return RedirectToAction("ListPatient", "Appointment");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"API isteği başarısız: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"API isteği başarısız: {ex}");
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("DoctorLogin", "Auth");
        }
    }
}
