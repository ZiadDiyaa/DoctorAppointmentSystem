using DoctorAppointmentSystem.Application;
using DoctorAppointmentSystem.Application.DoctorPracticeAssignmentManagement;
using DoctorAppointmentSystem.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentSystem.Server.Controllers
{
    [Route("DoctorPracticeAssignment")]
    public class DoctorPracticeAssignmentController : Controller
    {
        private readonly IManageDoctorPractice _manageDoctorPractice;

        public DoctorPracticeAssignmentController(IManageDoctorPractice manageDoctorPractice)
        {
            _manageDoctorPractice = manageDoctorPractice;
        }

        [HttpGet("{doctorPracticeID}")]
        [Route("GetDoctorPracticeAssignment")]
        public IActionResult GetDoctorPracticeAssignment(int doctorPracticeID)
        {
            var result = _manageDoctorPractice.GetDoctorPracticeAssignment(doctorPracticeID);
            
            if (result.Succeeded)
            {
                return View(result.Result);  // Return the view with the result
            }
            else
            {
                return View("Error");  // Return an error view with the messages
            }
        }

        [HttpGet]
        [Route("GetAllDoctorPracticeAssignments")]
        public IActionResult GetAllDoctorPracticeAssignments()
        {
            var result = _manageDoctorPractice.GetAllDoctorPracticeAssignments();

            if (result.Succeeded)
            {
                return View(result.Result);  // Return the view with the collection of results
            }
            else
            {
                return View("Error");  // Return an error view with the messages
            }
        }

        [HttpPost]
        [Route("AddDoctorPracticeAssignment")]
        public IActionResult AddDoctorPracticeAssignment(DoctorPracticeAssignmentDTO doctorPracticeAssignmentDTO)
        {
            var result = _manageDoctorPractice.AddDoctorPracticeAssignment(doctorPracticeAssignmentDTO);

            if (result.Succeeded)
            {
                return RedirectToAction("GetAllDoctorPracticeAssignments");  // Redirect to the list view after successful addition
            }
            else
            {
                return View("Error" );  // Return an error view with the messages
            }
        }

        [HttpPut]
        [Route("UpdateDoctorPracticeAssignment")]
        public IActionResult UpdateDoctorPracticeAssignment(DoctorPracticeAssignmentDTO doctorPracticeAssignmentDTO)
        {
            var result = _manageDoctorPractice.UpdateDoctorPracticeAssignment(doctorPracticeAssignmentDTO);

            if (result.Succeeded)
            {
                return RedirectToAction("GetAllDoctorPracticeAssignments");  // Redirect to the list view after successful update
            }
            else
            {
                return View("Error" );  // Return an error view with the messages
            }
        }

        [HttpDelete("{doctorPracticeID}")]
        [Route("DeleteDoctorPracticeAssignment")]
        public IActionResult DeleteDoctorPracticeAssignment(int doctorPracticeID)
        {
            var result = _manageDoctorPractice.DeleteDoctorPracticeAssignment(doctorPracticeID);

            if (result.Succeeded)
            {
                return RedirectToAction("GetAllDoctorPracticeAssignments");  // Redirect to the list view after successful deletion
            }
            else
            {
                return View("Error" );  // Return an error view with the messages
            }
        }
    }
}