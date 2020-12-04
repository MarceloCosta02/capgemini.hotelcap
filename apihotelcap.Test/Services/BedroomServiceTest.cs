using apihotelcap.Domain.RequestModels.BedroomRequests;
using apihotelcap.Domain.ResponseModels.Bedroom.BedroomResponses;
using apihotelcap.Interfaces.Repository;
using apihotelcap.Services;
using AutoFixture;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace apihotelcap.Test.Services
{
    public class BedroomServiceTest
    {
        private BedroomCreateRequest _bedroom;
        private BedroomService _service;
        private Fixture _fixture = new Fixture();
        private IBedroomRepository _repository;
        private BedroomAndBedroomTypeResponse _response;
        private List<BedroomAndBedroomTypeResponse> _list;


        public BedroomServiceTest()
        {
            _bedroom = _fixture.Create<BedroomCreateRequest>();
            _list = _fixture.Create<List<BedroomAndBedroomTypeResponse>>();
            _response = _fixture.Create<BedroomAndBedroomTypeResponse>();
            _repository = Substitute.For<IBedroomRepository>();
            _service = new BedroomService(_repository);
        }

        [Fact]
        public void Insert_NoBedroonThrowsException()
        {
            _repository.InsertBedroom(_bedroom);
            _bedroom.NoBedroom = 0;

            Assert.Throws<Exception>(() => _service.InsertBedroom(_bedroom));
        }

        [Fact]
        public void Insert_SituationThrowsExeption()
        {
            _repository.InsertBedroom(_bedroom);
            _bedroom.Situation = "C";

            Assert.Throws<Exception>(() => _service.InsertBedroom(_bedroom));
        }

        [Fact]
        public void Insert_IdBedroomTypeThrowsExeption()
        {
            _repository.InsertBedroom(_bedroom);
            _bedroom.IdBedroomType = 0;

            Assert.Throws<Exception>(() => _service.InsertBedroom(_bedroom));
        }

        [Fact]
        public void Validate_IdBedroomTypeDontExists()
        {
            _repository.InsertBedroom(_bedroom);
            _bedroom.IdBedroomType = 1829189;

            Assert.Throws<Exception>(() => _service.InsertBedroom(_bedroom));
        }

        [Fact]
        public void GetByIdBedroomType_FoundData()
        {
            const int IdBedroomType = 1;

            _repository.GetBedroomByIdBedroomType(IdBedroomType).Returns(_list);

            var result = _service.GetBedroomByIdBedroomType(IdBedroomType);
            result.Should().NotBeNull();
        }

        [Fact]
        public void GetByd_FoundData()
        {
            const int Id = 1;

            _repository.GetBedroomById(Id).Returns(_response);

            var result = _service.GetBedroomById(Id);

            result.Should().NotBeNull();
        }
    }
}
