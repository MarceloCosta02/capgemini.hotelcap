using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apihotelcap.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        [HttpGet]
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
