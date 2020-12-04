using System;
using System.Threading.Tasks;
using apihotelcap.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apihotelcap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _service;

        public InvoiceController(IInvoiceService service)
        {
            _service = service;
        }

        // GET 
        /// <summary>
        /// Envia uma notificação para as ocupacoes nao pagas
        /// </summary>
        /// <returns>Uma nova ocupação cadastrada</returns>
        /// <response code="200">Retorna que a operação foi criada</response>
        /// <response code="400">Se a operação não for criada</response>  
        [HttpGet]
        [Authorize(Roles = "ADM")]
        public async Task<IActionResult> SendOccupationsDontPaid()
        {
            try
            {
                var result = await _service.GetOccupationsDontPaid();

                if(result.Status == 200)
                    return new ObjectResult(result) { StatusCode = StatusCodes.Status200OK };
                else
                    return new ObjectResult(result) { StatusCode = result.Status };

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
