using ScheduleAppointment.Models;

namespace ScheduleAppointment.Repositories
{
    public interface IAppointmentCollection
    {
        Task InsertAppointment(Appointment appointment);
        Task UpdateAppointment(Appointment appointment);
        Task DeleteAppointment(string id);


        Task<List<Appointment>> GetAllAppointments();
        Task<Appointment> GetAppointmentById(string id);
    }
}
