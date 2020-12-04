using BoDi;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
using Xunit;

namespace apihotelcap.IntegratedTest.Steps
{
    [Binding]
    public class OccupationSteps
    {
        private string _host = "https://localhost:44314/api/";
        private IRestClient _restClient;
        private IRestRequest _restRequest;
        private IRestResponse _restResponse;
        private IObjectContainer _objectContainer;
        private int _qtdeDiarys;
        private DateTime _date;
        private string _situation;
        private int _idClient;
        private int _idBedroom;


        public OccupationSteps(IObjectContainer objectContainer) => _objectContainer = objectContainer;

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

        [Given(@"que o endpoint occupation é '(.*)'")]
        public void DadoQueAUrlDoEndPointEh(string endpoint) => _restRequest.Resource = endpoint;

        [Given(@"que o método http do occupation é '(.*)'")]
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


        [Given(@"que a quantidade de diarias é (.*)")]
        public void DadoQueAQtdeDiarysDaOcupacaoEh(int qtdeDiarys) => _qtdeDiarys = qtdeDiarys;

        [Given(@"que a situacao é (.*)")]
        public void DadoQueASituacaoDaOcupacaoEh(string situation) => _situation = situation;

        [Given(@"que a data é (.*)")]
        public void DadoQueADataDaOcupacaoEh(DateTime date) => _date = date;

        [Given(@"que o Id do Quarto é (.*)")]
        public void DadoQueOIdDoQuartoDaOcupacaoEh(int idBedroom) => _idBedroom = idBedroom;

        [Given(@"que o Id do Cliente é (.*)")]
        public void DadoQueOIdDoClienteDaOcupacaoEh(int idClient) => _idClient = idClient;

        [When(@"obter a ocupacao")]
        public void QuandoObterAOcupacao() => Occupation();


        [Then(@"a resposta de occupation será (.*)")]
        public void EntaoARespostaSera(HttpStatusCode statusCode) => Assert.Equal(statusCode, _restResponse.StatusCode);


        public void Occupation()
        {
            _restRequest.AddHeader("Content-Type", "application/json");
                                   
            _restRequest.AddJsonBody(new 
            { 
                QtdeDiarys = _qtdeDiarys, 
                Date = _date, 
                Situation = _situation, 
                IdClient = _idClient , 
                IdBedroom = _idBedroom 
            });

            _restClient.BaseUrl = new Uri(_host);
            _restResponse = _restClient.Execute(_restRequest);
        }
    }
}
