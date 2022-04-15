
namespace Tests.Integration
{
    using AutoMapper;
    using Domain.Interfaces;
    using Helpers;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using MongoSandbox.Config;
    using Storage.Data;
    using Storage.Models;
    using Storage.Models.Enums;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Tests.DataManagement;
    using Xunit;

    public class CarrierRatesRepositoryTests
    {
        private readonly IConfiguration _configuration;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IMapper _mapper;
        private readonly ISettingsHelper _settingsHelper;
        private CarrierRatesManagement _carrierRatesManagement;
        private CarrierRatesRepository _carrierRateRepository;

        private const int CarrierId = 100;

        public CarrierRatesRepositoryTests()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            _loggerFactory = new LoggerFactory();

            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(new List<Profile>
                {
                    new MappingProfile()
                });
            }));

            _settingsHelper = new SettingsHelper(_configuration);
            _carrierRatesManagement = new CarrierRatesManagement(_settingsHelper);
            _carrierRateRepository = new CarrierRatesRepository(_settingsHelper);
        }

        [Fact]
        public async Task CarrierRateRepository_Test()
        {
            //var rate = _carrierRatesManagement.CreateRate(CarrierId, ChargeCode.Team | ChargeCode.StopOffCharge | ChargeCode.TWIC | ChargeCode.HazMat);
            //await _carrierRatesManagement.InsertCarrierRateAsync(rate).ConfigureAwait(false);

            var filter = (int)(ChargeCode.Team | ChargeCode.TWIC);

            var result = _carrierRateRepository.SearchAsync(filter).ConfigureAwait(false);
        }

    }
}
