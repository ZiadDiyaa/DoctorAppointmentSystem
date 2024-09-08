using DoctorAppointmentSystem.Application;
using DoctorAppointmentSystem.Application.DoctorPracticeAssignmentManagement;
using DoctorAppointmentSystem.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentSystem.Server.Controllers
{
    public class DoctorPracticeAssignmentController : Controller
    {
        private readonly IManageDoctorPractice _manageDoctorPractice;

        public DoctorPracticeAssignmentController(IManageDoctorPractice manageDoctorPractice)
        {
            _manageDoctorPractice = manageDoctorPractice;
        }

        [HttpGet("{doctorPracticeID}")]
        public IActionResult GetDoctorPracticeAssignment(int doctorPracticeID)
        {
            var result = _manageDoctorPractice.GetDoctorPracticeAssignment(doctorPracticeID);
            
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
        public IActionResult GetAllDoctorPracticeAssignments()
        {
            var result = _manageDoctorPractice.GetAllDoctorPracticeAssignments();

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
        public IActionResult AddDoctorPracticeAssignment(DoctorPracticeAssignmentDTO doctorPracticeAssignmentDTO)
        {
            var result = _manageDoctorPractice.AddDoctorPracticeAssignment(doctorPracticeAssignmentDTO);

            if (result.Succeeded)
            {
                return RedirectToAction("GetAllDoctorPracticeAssignments");  // Redirect to the list view after successful addition
            }
            else
            {
                return View("Error", result.Messages);  // Return an error view with the messages
            }
        }

        [HttpPut]
        public IActionResult UpdateDoctorPracticeAssignment(DoctorPracticeAssignmentDTO doctorPracticeAssignmentDTO)
        {
            var result = _manageDoctorPractice.UpdateDoctorPracticeAssignment(doctorPracticeAssignmentDTO);

            if (result.Succeeded)
            {
                return RedirectToAction("GetAllDoctorPracticeAssignments");  // Redirect to the list view after successful update
            }
            else
            {
                return View("Error", result.Messages);  // Return an error view with the messages
            }
        }

        [HttpDelete("{doctorPracticeID}")]
        public IActionResult DeleteDoctorPracticeAssignment(int doctorPracticeID)
        {
            var result = _manageDoctorPractice.DeleteDoctorPracticeAssignment(doctorPracticeID);

            if (result.Succeeded)
            {
                return RedirectToAction("GetAllDoctorPracticeAssignments");  // Redirect to the list view after successful deletion
            }
            else
            {
                return View("Error", result.Messages);  // Return an error view with the messages
            }
        }
    }
}