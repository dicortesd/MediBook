using MongoDB.Bson;
using MongoDB.Driver;
using ScheduleAppointment.Models;

namespace ScheduleAppointment.Repositories
{
    public class AppointmenrtCollection : IAppointmentCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Appointment> Collection;

        public AppointmenrtCollection()
        {
            Collection = _repository.db.GetCollection<Appointment>("Appointments");
        }
        public async Task DeleteAppointment(string id)
        {
            var filter = Builders<Appointment>.Filter.Eq(s => s.Id, new ObjectId(id));
                await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Appointment>> GetAllAppointments()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
            
        }

        public async Task<Appointment> GetAppointmentById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task InsertAppointment(Appointment appointment)
        {
            await Collection.InsertOneAsync(appointment);   
        }

        public async Task UpdateAppointment(Appointment appointment)
        {
            var filter = Builders<Appointment>
                .Filter
                .Eq(s => s.Id, appointment.Id);
            await Collection.ReplaceOneAsync(filter, appointment);
        }
    }
}
