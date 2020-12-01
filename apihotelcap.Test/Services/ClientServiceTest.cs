using apihotelcap.Domain.RequestModels.Bedroom.BedroomResponses;
using apihotelcap.Domain.RequestModels.BedroomRequests;
using apihotelcap.Domain.RequestModels.ClientRequests;
using apihotelcap.Domain.ResponseModels.ClientResponses;
using apihotelcap.Interfaces.Repository;
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
    public class ClientServiceTest
    {
        private ClientCreateRequest _client;
        private ClientService _service;
        private Fixture _fixture = new Fixture();
        private IClientRepository _repository;
        private ClientResponse _response;
        private List<ClientResponse> _list;

        public ClientServiceTest()
        {
            _client = _fixture.Create<ClientCreateRequest>();
            _list = _fixture.Create<List<ClientResponse>>();
            _response = _fixture.Create<ClientResponse>();
            _repository = Substitute.For<IClientRepository>();
            _service = new ClientService(_repository);
        }

        [Fact]
        public void Insert_NameThrowsException()
        {
            _repository.InsertClient(_client);
            _client.Name = "";

            Assert.Throws<Exception>(() => _service.InsertClient(_client));
        }

        [Fact]
        public void Insert_CPFThrowsExeption()
        {
            _repository.InsertClient(_client);
            _client.CPF = "";

            Assert.Throws<Exception>(() => _service.InsertClient(_client));
        }

        [Fact]
        public void Insert_HashThrowsExeption()
        {
            _repository.InsertClient(_client);
            _client.Hash = "";

            Assert.Throws<Exception>(() => _service.InsertClient(_client));
        }                

        [Fact]
        public void GetByd_FoundData()
        {
            const int Id = 1;

            _repository.GetClientById(Id).Returns(_response);

            var result = _service.GetClientById(Id);

            result.Should().NotBeNull();
        }

    }
}

