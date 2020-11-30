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
    public class BedroomServiceTest
    {
        private Bedroom _bedroom;
        private BedroomService _service;
        private Fixture _fixture = new Fixture();
        private IBedroomRepository _repository;


        public BedroomServiceTest()
        {
            _bedroom = _fixture.Create<Bedroom>();
            _service = new BedroomService(_repository);
            _repository = Substitute.For<IBedroomRepository>();
        }

        [Fact]
        public void Insert_NoBedroonThrowsException()
        {
            _repository.InsertBedroom(_bedroom).Returns(_bedroom);
            _bedroom.NoBedroom = 0;

            Assert.Throws<Exception>(() => _service.InsertBedroom(_bedroom));
        }

        [Fact]
        public void Insert_SituationThrowsExeption()
        {
            _repository.InsertBedroom(_bedroom).Returns(_bedroom);
            _bedroom.Situation = "C";

            Assert.Throws<Exception>(() => _service.InsertBedroom(_bedroom));
        }

        [Fact]
        public void Insert_IdBedroomTypeThrowsExeption()
        {
            _repository.InsertBedroom(_bedroom).Returns(_bedroom);
            _bedroom.IdBedroomType = 0;

            Assert.Throws<Exception>(() => _service.InsertBedroom(_bedroom));
        }

        [Fact]
        public void Validate_IdBedroomTypeDontExists()
        {
            _repository.InsertBedroom(_bedroom).Returns(_bedroom);
            _bedroom.IdBedroomType = 1829189;

            Assert.Throws<Exception>(() => _service.InsertBedroom(_bedroom));
        }
    }
}
