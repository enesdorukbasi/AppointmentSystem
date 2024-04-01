using AppointmentSystem.UI.Application.DTOs;
using AppointmentSystem.UI.Domain.Constants;
using AppointmentSystem.UI.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace AppointmentSystem.UI.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IMapper _mapper;

        public AppointmentController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult List()
        {
            var userClaims = HttpContext.User.Claims;
            if (userClaims.IsNullOrEmpty())
            {
                return RedirectToAction("PatientLogin", "Auth");
            }
            var jsonUser = userClaims.Single(x => x.Type == "jsonUser");
            var user = JsonConvert.DeserializeObject<IDTO<DoctorUser>>(jsonUser.Value);

            if (!string.IsNullOrEmpty(user!.data!.Degree!))
            {
                return RedirectToAction("ListDoctor");
            }
            return RedirectToAction("ListPatient");

        }

        [Authorize]
        public async Task<IActionResult> ListDoctor()
        {
            var userClaims = HttpContext.User.Claims;
            if (userClaims.IsNullOrEmpty())
            {
                return RedirectToAction("PatientLogin", "Auth");
            }
            var token = userClaims.Single(x => x.Type == "token");
            var jsonUser = userClaims.Single(x => x.Type == "jsonUser");
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
                var user = JsonConvert.DeserializeObject<IDTO<DoctorUser>>(jsonUser.Value);
                var content = new StringContent(JsonConvert.SerializeObject(new GetAllAppointmentsByDoctorId() { DoctorId = user!.data!.AppUserId }), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.GetAsync(ApiConstants.apiBaseUrl + $"Appointment/GetAllByDoctorId/{user.data.AppUserId}");
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var dataModel = JsonConvert.DeserializeObject<IDTO<List<Appointment>>>(jsonResponse);
                    return View(dataModel!.data);
                }
            }
            return View(new IDTO<List<Appointment>>());
        }

        [Authorize]
        public async Task<IActionResult> ListPatient()
        {
            var userClaims = HttpContext.User.Claims;
            if (userClaims.IsNullOrEmpty())
            {
                return RedirectToAction("PatientLogin", "Auth");
            }
            var token = userClaims.Single(x => x.Type == "token");
            var jsonUser = userClaims.Single(x => x.Type == "jsonUser");
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
                var user = JsonConvert.DeserializeObject<IDTO<DoctorUser>>(jsonUser.Value);
                HttpResponseMessage response = await httpClient.GetAsync(ApiConstants.apiBaseUrl + $"Appointment/GetAllByPatientId/{user?.data?.AppUserId}");
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var dataModel = JsonConvert.DeserializeObject<IDTO<List<Appointment>>>(jsonResponse);
                    return View(dataModel?.data);
                }
            }
            return View(new IDTO<List<Appointment>>());
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            using (var httpClient = new HttpClient())
            {
                var userClaims = HttpContext.User.Claims;
                if (userClaims.IsNullOrEmpty())
                {
                    return RedirectToAction("PatientLogin", "Auth");
                }
                var token = userClaims.Single(x => x.Type == "token");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
                HttpResponseMessage responseDoctorUsers = await httpClient.GetAsync(ApiConstants.apiBaseUrl + "DoctorUser/GetAllDoctorsByPoliclinicId/0");
                if (responseDoctorUsers.IsSuccessStatusCode)
                {
                    string jsonResponseDoctors = await responseDoctorUsers.Content.ReadAsStringAsync();
                    var dataModelDoctors = JsonConvert.DeserializeObject<IDTO<List<DoctorUser>>>(jsonResponseDoctors);
                    var doctorsSelectList = new List<SelectListItem>();
                    foreach (var doctor in dataModelDoctors?.data!)
                    {
                        doctorsSelectList.Add(new SelectListItem { Value = doctor.AppUserId.ToString(), Text = doctor.Card + " " + doctor.Policlinic?.Definition });
                    }
                    return View(new CreateAppointmentDTO()
                    {
                        DoctorUsers = new SelectList(doctorsSelectList, "Value", "Text"),
                    });
                }
            }
            return View(new CreateAppointmentDTO());
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateAppointmentDTO appointment)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var userClaims = HttpContext.User.Claims;
                    if (userClaims.IsNullOrEmpty())
                    {
                        return RedirectToAction("PatientLogin", "Auth");
                    }
                    var token = userClaims.Single(x => x.Type == "token");
                    var jsonUser = userClaims.Single(x => x.Type == "jsonUser");
                    var user = JsonConvert.DeserializeObject<IDTO<DoctorUser>>(jsonUser.Value);
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
                    var model = new Appointment()
                    {
                        StartDate = appointment.StartDate,
                        EndDate = appointment.StartDate.AddHours(1),
                        Description = appointment.Description,
                        PatientId = user!.data!.AppUserId,
                        DoctorId = appointment.DoctorId,
                        IsCancelled = false,
                        IsClosedByDoctor = false,
                    };
                    var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync(ApiConstants.apiBaseUrl + "Appointment/Create", content);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var responseModel = JsonConvert.DeserializeObject<IDTO<Appointment>>(jsonResponse);
                        if (responseModel != null)
                        {
                            return RedirectToAction("ListPatient");
                        }
                    }
                }
                catch (Exception)
                {
                    return View(appointment);
                }
            }
            return View(appointment);
        }

        [Authorize]
        public async Task<IActionResult> Update(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var userClaims = HttpContext.User.Claims;
                if (userClaims.IsNullOrEmpty())
                {
                    return RedirectToAction("PatientLogin", "Auth");
                }
                var token = userClaims.Single(x => x.Type == "token");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
                HttpResponseMessage response = await httpClient.GetAsync(ApiConstants.apiBaseUrl + $"Appointment/GetById/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var dataModel = JsonConvert.DeserializeObject<IDTO<Appointment>>(jsonResponse);
                    var dto = new UpdateAppointmentDTO()
                    {
                        AppointmentID = dataModel!.data!.AppointmentID,
                        StartDate = dataModel.data.StartDate,
                        EndDate = dataModel.data.EndDate,
                        PatientId = dataModel.data.AppointmentID,
                        DoctorId = dataModel.data.AppointmentID,
                        IsCancelled = dataModel.data.IsCancelled,
                        IsClosedByDoctor = dataModel.data.IsClosedByDoctor,
                        Description = dataModel.data.Description,
                    };
                    return View(dto);
                }
            }
            return View(new UpdateAppointmentDTO());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Update(UpdateAppointmentDTO dto)
        {
            using (var httpClient = new HttpClient())
            {
                var userClaims = HttpContext.User.Claims;
                if (userClaims.IsNullOrEmpty())
                {
                    return RedirectToAction("PatientLogin", "Auth");
                }
                var token = userClaims.Single(x => x.Type == "token");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
                var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PutAsync(ApiConstants.apiBaseUrl + "Appointment/Update", content);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseModel = JsonConvert.DeserializeObject<IDTO<Appointment>>(jsonResponse);
                    if (responseModel != null)
                    {
                        return RedirectToAction("ListPatient");
                    }
                }
            }
            return View(dto);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var userClaims = HttpContext.User.Claims;
                if (userClaims.IsNullOrEmpty())
                {
                    return RedirectToAction("PatientLogin", "Auth");
                }
                var token = userClaims.Single(x => x.Type == "token");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
                HttpResponseMessage responseDelete = await httpClient.DeleteAsync(ApiConstants.apiBaseUrl + $"Appointment/Delete/{id}");
                if (responseDelete != null)
                {
                    string jsonDelete = await responseDelete.Content.ReadAsStringAsync();
                    var dataDelete = JsonConvert.DeserializeObject<IDTO<object?>>(jsonDelete);
                    if (dataDelete?.status == 200)
                    {
                        return RedirectToAction("ListPatient");
                    }
                }
            }
            return RedirectToAction("ListPatient");
        }
    }
}
