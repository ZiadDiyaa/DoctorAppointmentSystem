using DoctorAppointmentSystem.Application;
using DoctorAppointmentSystem.Application.DoctorPracticeManagement;
using DoctorAppointmentSystem.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentSystem.Server.Controllers
{
    public class DoctorPracticeController : Controller
    {
        private readonly IManageDoctorPractice _manageDoctorPractice;

        public DoctorPracticeController(IManageDoctorPractice manageDoctorPractice)
        {
            _manageDoctorPractice = manageDoctorPractice;
        }

        [HttpGet("{doctorPracticeID}")]
        public IActionResult GetDoctorPractice(int doctorPracticeID)
        {
            var result = _manageDoctorPractice.GetDoctorPractice(doctorPracticeID);

            if (result.Succeeded)
            {
                return View(result.Result);  // Return the view with the result
            }
            else
            {
                return View("Error", result.Messages);  // Return an error view with the messages
            }
        }

        [HttpGet]
        public IActionResult GetAllDoctorPractices()
        {
            var result = _manageDoctorPractice.GetAllDoctorPractices();

            if (result.Succeeded)
            {
                return View(result.Result);  // Return the view with the collection of results
            }
            else
            {
                return View("Error", result.Messages);  // Return an error view with the messages
            }
        }

        [HttpPost]
        public IActionResult AddDoctorPractice(DoctorPracticeDTO doctorPracticeDTO)
        {
            var result = _manageDoctorPractice.AddDoctorPractice(doctorPracticeDTO);

            if (result.Succeeded)
            {
                return RedirectToAction("GetAllDoctorPractices");  // Redirect to the list view after successful addition
            }
            else
            {
                return View("Error", result.Messages);  // Return an error view with the messages
            }
        }

        [HttpPut]
        public IActionResult UpdateDoctorPractice(DoctorPracticeDTO doctorPracticeDTO)
        {
            var result = _manageDoctorPractice.UpdateDoctorPractice(doctorPracticeDTO);

            if (result.Succeeded)
            {
                return RedirectToAction("GetAllDoctorPractices");  // Redirect to the list view after successful update
            }
            else
            {
                return View("Error", result.Messages);  // Return an error view with the messages
            }
        }

        [HttpDelete("{doctorPracticeID}")]
        public IActionResult DeleteDoctorPractice(int doctorPracticeID)
        {
            var result = _manageDoctorPractice.DeleteDoctorPractice(doctorPracticeID);

            if (result.Succeeded)
            {
                return RedirectToAction("GetAllDoctorPractices");  // Redirect to the list view after successful deletion
            }
            else
            {
                return View("Error", result.Messages);  // Return an error view with the messages
            }
        }
    }
}