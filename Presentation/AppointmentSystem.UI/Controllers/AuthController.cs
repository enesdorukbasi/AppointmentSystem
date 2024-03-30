using AppointmentSystem.UI.Constants;
using AppointmentSystem.UI.DTOs;
using AppointmentSystem.UI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace AppointmentSystem.UI.Controllers
{
    public class AuthController : Controller
    {
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
                    HttpResponseMessage response = await httpClient.PostAsync(ApiConstants.apiBaseUrl + "LoginDoctor", content);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var loginModel = JsonSerializer.Deserialize<DoctorUser>(jsonResponse, new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });
                        if(loginModel != null)
                        {
                           
                        }
                        Console.WriteLine(jsonResponse);
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
                    HttpResponseMessage response = await httpClient.PostAsync(ApiConstants.apiBaseUrl + "LoginPatient", content);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var loginModel = JsonSerializer.Deserialize<DoctorUser>(jsonResponse, new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });
                        if (loginModel != null)
                        {

                        }
                        Console.WriteLine(jsonResponse);
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
    }
}
