using apihotelcap.Domain.RequestModels.Bedroom.BedroomResponses;
using apihotelcap.Domain.RequestModels.BedroomRequests;
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
    public class BedroomTypeServiceTest
    {
        private BedroomTypeCreateRequest _bedroomType;
        private BedroomTypeService _service;
        private Fixture _fixture = new Fixture();
        private IBedroomTypeRepository _repository;
        private BedroomTypeResponse _response;
        private List<BedroomTypeResponse> _list;

        public BedroomTypeServiceTest()
        {
            _bedroomType = _fixture.Create<BedroomTypeCreateRequest>();
            _list = _fixture.Create<List<BedroomTypeResponse>>();
            _response = _fixture.Create<BedroomTypeResponse>();
            _repository = Substitute.For<IBedroomTypeRepository>();
            _service = new BedroomTypeService(_repository);
        }

        [Fact]
        public void Insert_ValueThrowsException()
        {
            _repository.InsertBedroomType(_bedroomType);
            _bedroomType.Value = -29;

            Assert.Throws<Exception>(() => _service.InsertBedroomType(_bedroomType));
        }

        [Fact]
        public void Insert_DescriptionThrowsExeption()
        {
            _repository.InsertBedroomType(_bedroomType);
            _bedroomType.Description = "";

            Assert.Throws<Exception>(() => _service.InsertBedroomType(_bedroomType));
        }

        [Fact]
        public void GetAll_FoundData()
        {
            _repository.GetAllBedroomsType().Returns(_list);

            var result = _service.GetAllBedroomsType();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void GetByd_FoundData()
        {
            const int Id = 1;

            _repository.GetBedroomTypeById(Id).Returns(_response);

            var result = _service.GetBedroomTypeById(Id);

            result.Should().NotBeNull();
        }

    }
}

