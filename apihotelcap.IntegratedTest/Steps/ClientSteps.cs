using BoDi;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;
using Xunit;

namespace apihotelcap.IntegratedTest.Steps
{
    [Binding]
    public class ClientStep
    {
        private string _host = "https://localhost:44314/api/";
        private IRestClient _restClient;
        private IRestRequest _restRequest;
        private IRestResponse _restResponse;
        private IObjectContainer _objectContainer;
        private int _id;
        private string _name;
        private string _cpf;
        private string _hash;

        public ClientStep(IObjectContainer objectContainer) => _objectContainer = objectContainer;

        [BeforeScenario]
        public void Setup()
        {
            _restClient = new RestClient();
            _objectContainer.RegisterInstanceAs(_restClient);
            _restRequest = new RestRequest();
            _objectContainer.RegisterInstanceAs(_restRequest);
            _restResponse = new RestResponse();
            _objectContainer.RegisterInstanceAs(_restResponse);
            _restClient.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
        }        

        [Given(@"que o endpoint client é '(.*)'")]
        public void DadoQueAUrlDoEndPointEh(string endpoint) => _restRequest.Resource = endpoint;

        [Given(@"que o método http do client é '(.*)'")]
        public void DadoQueOMetodoHttpEh(string metodo)
        {
            if (metodo.ToUpper() == "GET")
                _restRequest.Method = Method.GET;

            if (metodo.ToUpper() == "POST")
                _restRequest.Method = Method.POST;

            if (metodo.ToUpper() == "PUT")
                _restRequest.Method = Method.PUT;

            if (metodo.ToUpper() == "DELETE")
                _restRequest.Method = Method.DELETE;
        }


        [Given(@"que o id é (.*)")]
        public void DadoQueOIdDoClienteEh(int id) => _id = id;

        [Given(@"que o name é (.*)")]
        public void DadoQueONomeDoClienteEh(string name) => _name = name;

        [Given(@"que o cpf é (.*)")]
        public void DadoQueOCPFDoClienteEh(string cpf) => _cpf = cpf;

        [Given(@"que o hash é (.*)")]
        public void DadoQueOHashDoClienteEh(string hash) => _hash = hash;

        [When(@"obter o cliente")]
        public void QuandoObterOCliente() => Client();


        [Then(@"a resposta de client será (.*)")]
        public void EntaoARespostaSera(HttpStatusCode statusCode) => Assert.Equal(statusCode, _restResponse.StatusCode);


        public void Client()
        {
            _restRequest.AddHeader("Content-Type", "application/json");

            if(_restRequest.Method == Method.GET)
            {
                if (_id != 0)
                    _restRequest.AddParameter("id", _id);
            }               
            else if(_restRequest.Method == Method.POST)
                if(_cpf.Length < 11)
                {
                    var obj = new { Name = _name, Hash = _hash };
                    _restRequest.AddJsonBody(obj);
                }
                else
                {
                    var obj = new { Name = _name, CPF = _cpf, Hash = _hash };
                    _restRequest.AddJsonBody(obj);
                }

            _restClient.BaseUrl = new Uri(_host);
            _restResponse = _restClient.Execute(_restRequest);
        }
    }
}
