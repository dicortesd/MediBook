using Microsoft.AspNetCore.Mvc;
using ScheduleAppointment.Models;
using ScheduleAppointment.Repositories;

namespace ScheduleAppointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : Controller
    {
        private IAppointmentCollection db = new AppointmenrtCollection();
        [HttpGet]
        public async Task<IActionResult> GetAllApointments()
        {
            return Ok(await db.GetAllAppointments());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetApointmentsDetails(string id)
        {
            return Ok(await db.GetAppointmentById(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] Appointment appointment)
        {
            if (appointment == null) {
                return BadRequest();
            }    
            if (appointment.Id_paciente == null) {
                ModelState.AddModelError("id_paciente", "El identificador del paciente no puede estar vacio");
            }
            await db.InsertAppointment(appointment);
            return Created("Created", true);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment([FromBody] Appointment appointment, string id)
        {
            if (appointment == null)
            {
                return BadRequest();
            }
            if (appointment.Id_paciente == null)
            {
                ModelState.AddModelError("id_paciente", "El identificador del paciente no puede estar vacio");
            }
            appointment.Id =  new MongoDB.Bson.ObjectId(id);
            await db.UpdateAppointment(appointment);
            return Created("Created", true);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAppointment(string id)
        {
            await db.DeleteAppointment(id);
            return NoContent(); //success
        }
    }
}
