
namespace Storage.Data
{
    using Domain;
    using Domain.Interfaces;
    using MongoDB.Driver;
    using Storage.Models;
    using Storage.Models.Enums;
    using Domain = Domain.Models;

    public class CarrierRatesRepository
    {
        private readonly IMongoCollection<CarrierRate> _collection;

        public CarrierRatesRepository(ISettingsHelper settingsHelper)
        {
            var connection = settingsHelper.GetConnectionString();
            var db = new MongoClient(connection).GetDatabase(Constants.DatabaseName);
            _collection = db.GetCollection<CarrierRate>(Constants.CollectionName);
        }

        public async Task<IEnumerable<CarrierRate>> SearchAsync(int charges)
        {
            var filter = Builders<CarrierRate>.Filter.BitsAllSet("Charges", charges);

            var cursor = await _collection.FindAsync(filter).ConfigureAwait(false);
 
            return cursor.ToList();
        }
    }
}
