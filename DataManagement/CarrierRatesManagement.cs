using Domain;
using Domain.Interfaces;
using MongoDB.Driver;
using Storage.Models;
using Storage.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Tests.DataManagement
{
    public class CarrierRatesManagement
    {
        private readonly IMongoCollection<CarrierRate> _collection;

        public CarrierRatesManagement(ISettingsHelper settingsHelper)
        {
            var connection = settingsHelper.GetConnectionString();
            var db = new MongoClient(connection).GetDatabase(Constants.DatabaseName);
            _collection = db.GetCollection<CarrierRate>(Constants.CollectionName);
        }

        public async Task InsertCarrierRateAsync(CarrierRate carrierRate)
        {
            await _collection.InsertOneAsync(carrierRate).ConfigureAwait(false);
        }



        public async Task InsertCarrierRatesAsync(IEnumerable<CarrierRate> rates)
        {
            var bulkOps = new List<WriteModel<CarrierRate>>();
            foreach (var rate in rates)
            {
                var upsertOne = new ReplaceOneModel<CarrierRate>(
                    Builders<CarrierRate>.Filter.Where(
                        rg => rg.CarrierId == rate.CarrierId), rate)
                { IsUpsert = true };
                bulkOps.Add(upsertOne);
                //TakeOwnershipOfRoutingGuide(routingGuide.ShipperRateLaneId);
            }
            await _collection.BulkWriteAsync(bulkOps).ConfigureAwait(false);
        }


        public CarrierRate CreateRate(int carrierId, ChargeCode charges)
        {
            return new CarrierRate
            {
                CarrierId = carrierId,
                Charges = charges
            };
        }
       
    }
}
