using BoDi;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
using Xunit;

namespace apihotelcap.IntegratedTest.Steps
{
    [Binding]
    public class BedroomTypeSteps
    {
        private string _host = "https://localhost:44314/api/";
        private IRestClient _restClient;
        private IRestRequest _restRequest;
        private IRestResponse _restResponse;
        private IObjectContainer _objectContainer;
        private int _id;
        private string _description;
        private double _value;

        public BedroomTypeSteps(IObjectContainer objectContainer) => _objectContainer = objectContainer;

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

        [Given(@"que o endpoint bedroomType é '(.*)'")]
        public void DadoQueAUrlDoEndPointEh(string endpoint) => _restRequest.Resource = endpoint;

        [Given(@"que o método http do bedroomType é '(.*)'")]
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


        [Given(@"que o id do tipo de quarto é (.*)")]
        public void DadoQueOIdDoTipoDeQuartoEh(int id) => _id = id;

        [Given(@"que a descricao é (.*)")]
        public void DadoQueADescricaoEh(string description) => _description = description;

        [Given(@"que o valor é (.*)")]
        public void DadoQueOValorEh(double value) => _value = value;

        [When(@"obter o tipo de quarto")]
        public void QuandoObterOTipoDeQuarto() => BedroomType();


        [Then(@"a resposta de bedroomType será (.*)")]
        public void EntaoARespostaSera(HttpStatusCode statusCode) => Assert.Equal(statusCode, _restResponse.StatusCode);


        public void BedroomType()
        {
            _restRequest.AddHeader("Content-Type", "application/json");

            if(_restRequest.Method == Method.GET)
            {
                if (_id != 0)
                    _restRequest.AddParameter("id", _id);
            }               
            else if(_restRequest.Method == Method.POST)
                _restRequest.AddJsonBody(new { Description = _description, Value = _value });

            _restClient.BaseUrl = new Uri(_host);
            _restResponse = _restClient.Execute(_restRequest);
        }
    }
}
