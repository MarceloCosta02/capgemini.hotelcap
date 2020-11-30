using apihotelcap.Interfaces.Repository;
using apihotelcap.Models;
using apihotelcap.Services;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace apihotelcap.Test.Services
{
    public class BedroomTypeServiceTest
    {
        private BedroomType _bedroomType;
        private BedroomTypeService _service;
        private Fixture _fixture = new Fixture();
        private IBedroomTypeRepository _repository;


        public BedroomTypeServiceTest()
        {
            _bedroomType = _fixture.Create<BedroomType>();
            _service = new BedroomTypeService(_repository);
            _repository = Substitute.For<IBedroomTypeRepository>();
        }

        [Fact]
        public void Insert_ValueThrowsException()
        {
            _repository.InsertBedroomType(_bedroomType).Returns(_bedroomType);
            _bedroomType.Value = -29;

            Assert.Throws<Exception>(() => _service.InsertBedroomType(_bedroomType));
        }

        [Fact]
        public void Insert_DescriptionThrowsExeption()
        {
            _repository.InsertBedroomType(_bedroomType).Returns(_bedroomType);
            _bedroomType.Description = "";

            Assert.Throws<Exception>(() => _service.InsertBedroomType(_bedroomType));
        }      
    }
}
