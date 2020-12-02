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
    public class InvoiceSteps
    {
        private string _host = "https://localhost:44314/api/";
        private IRestClient _restClient;
        private IRestRequest _restRequest;
        private IRestResponse _restResponse;
        private IObjectContainer _objectContainer;   

        public InvoiceSteps(IObjectContainer objectContainer) => _objectContainer = objectContainer;

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

        [Given(@"que o endpoint invoice é '(.*)'")]
        public void DadoQueAUrlDoEndPointEh(string endpoint) => _restRequest.Resource = endpoint;

        [Given(@"que o método http da invoice é '(.*)'")]
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

                
        [When(@"obter a fatura")]
        public void QuandoObterAOcupacao() => Invoice();

        [Then(@"a resposta de invoice será (.*)")]
        public void EntaoARespostaSera(HttpStatusCode statusCode) => Assert.Equal(statusCode, _restResponse.StatusCode);


        public void Invoice()
        {
            _restRequest.AddHeader("Content-Type", "application/json");                                   

            _restClient.BaseUrl = new Uri(_host);
            _restResponse = _restClient.Execute(_restRequest);
        }
    }
}
