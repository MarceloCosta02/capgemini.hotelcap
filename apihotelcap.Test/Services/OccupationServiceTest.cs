using apihotelcap.Domain.RequestModels.ClientRequests;
using apihotelcap.Interfaces.Repository;
using apihotelcap.Services;
using AutoFixture;
using NSubstitute;
using System;
using Xunit;

namespace apihotelcap.Test.Services
{
    public class OccupationServiceTest
    {
        private OccupationCreateRequest _occupation;
        private OccupationService _service;
        private Fixture _fixture = new Fixture();
        private IOccupationRepository _repository;      

        public OccupationServiceTest()
        {
            _occupation = _fixture.Create<OccupationCreateRequest>();
            _repository = Substitute.For<IOccupationRepository>();
            _service = new OccupationService(_repository);
        }

        [Fact]
        public void Insert_QtdeDiarysThrowsException()
        {
            _repository.InsertOccupation(_occupation);
            _occupation.QtdeDiarys = 0;

            Assert.Throws<Exception>(() => _service.InsertOccupation(_occupation));
        }

        [Fact]
        public void Insert_IdClientThrowsExeption()
        {
            _repository.InsertOccupation(_occupation);
            _occupation.IdClient = 0;

            Assert.Throws<Exception>(() => _service.InsertOccupation(_occupation));
        }

        [Fact]
        public void Insert_IdBedroomThrowsExeption()
        {
            _repository.InsertOccupation(_occupation);
            _occupation.IdBedroom = 0;

            Assert.Throws<Exception>(() => _service.InsertOccupation(_occupation));
        }

    }
}

