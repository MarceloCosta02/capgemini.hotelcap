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
    public class BedroomSteps
    {
        private string _host = "https://localhost:44314/api/";
        private IRestClient _restClient;
        private IRestRequest _restRequest;
        private IRestResponse _restResponse;
        private IObjectContainer _objectContainer;
        private int _id;
        private int _idBedroomType;
        private int _floor;
        private int _noBedroom;
        private string _situation;

        public BedroomSteps(IObjectContainer objectContainer) => _objectContainer = objectContainer;

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

        [Given(@"que o endpoint bedroom é '(.*)'")]
        public void DadoQueAUrlDoEndPointEh(string endpoint) => _restRequest.Resource = endpoint;

        [Given(@"que o método http do bedroom é '(.*)'")]
        public void DadoQueOMetodoHttpEh(string metodo)
        {
            if (metodo.ToUpper() == "GET")
                _restRequest.Method = Method.GET;

            if (metodo.ToUpper() == "POST")
                _restRequest.Method = Method.POST;

            if (metodo.ToUpper() == "PUT")
                _restRequest.Method = Method.PUT;

            if (metodo.ToUpper() == "PATCH")
                _restRequest.Method = Method.PATCH;

            if (metodo.ToUpper() == "DELETE")
                _restRequest.Method = Method.DELETE;
        }

        [Given(@"que o id do quarto é (.*)")]
        public void DadoQueOIdEh(int id) => _id = id;

        [Given(@"que o id do tipo de quarto referenciado com o quarto é (.*)")]
        public void DadoQueOIdDoTipoDeQuartoReferenciadoComQuartoEh(int idBedroomType) => _idBedroomType = idBedroomType;

        [Given(@"que o andar é (.*)")]
        public void DadoQueOAndarEh(int floor) => _floor = floor;

        [Given(@"que o numero do quarto é (.*)")]
        public void DadoQueONumeroDoQuartoEh(int noBedroom) => _noBedroom = noBedroom;

        [Given(@"que a situacao do quarto é (.*)")]
        public void DadoQueASituacaoDoQuartoEh(string situation) => _situation = situation;

        [When(@"obter o quarto")]
        public void QuandoObterOQuarto() => Bedroom();


        [Then(@"a resposta de bedroom será (.*)")]
        public void EntaoARespostaSera(HttpStatusCode statusCode) => Assert.Equal(statusCode, _restResponse.StatusCode);


        public void Bedroom()
        {
            _restRequest.AddHeader("Content-Type", "application/json");

            if(_restRequest.Method == Method.GET)
            {
                if (_restRequest.Resource == "Bedroom/getByIdBedroomType")
                {
                    if (_idBedroomType != 0)
                        _restRequest.AddParameter("idBedroomType", _idBedroomType);
                }
                else if (_restRequest.Resource == "Bedroom/getByIdId")
                {
                    if (_id != 0)
                        _restRequest.AddParameter("id", _id);
                }              
            }               
            else if(_restRequest.Method == Method.POST)
                _restRequest.AddJsonBody(new { Floor = _floor, NoBedroom = _noBedroom, Situation = _situation, IdBedroomType = _idBedroomType });
            
            else if(_restRequest.Method == Method.PATCH)
                _restRequest.AddJsonBody(new { Situation = _situation });
                if (_id != 0)
                    _restRequest.AddParameter("id", _id);

            _restClient.BaseUrl = new Uri(_host);
            _restResponse = _restClient.Execute(_restRequest);
        }
    }
}
