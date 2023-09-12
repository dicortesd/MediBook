using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ScheduleAppointment.Models
{
    public class Appointment
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Id_cita { get; set; }
        public string Id_doctor { get; set;}
        public string Id_paciente { get; set; }
        public string? Id_consultorio { get; set; }
        public DateTime Fecha_hora { get; set; }
        public string Tipo_cita { get; set; }
    }
}
