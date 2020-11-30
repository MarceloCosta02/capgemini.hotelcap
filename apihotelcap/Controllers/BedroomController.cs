using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apihotelcap.Interfaces.Services;
using apihotelcap.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace apihotelcap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BedroomController : ControllerBase
    {
        private readonly IBedroomService _service;

        public BedroomController(IBedroomService service)
        {
            _service = service;
        }

        // POST 
        /// <summary>
        /// Realiza a operação de deposito ou saque
        /// </summary>
        /// <param name="bedroom"></param>/>      
        /// <returns>Um novo quarto criado</returns>
        /// <response code="201">Retorna que a operação foi criada</response>
        /// <response code="400">Se a operação não for criada</response>  
        [HttpPost]
        public IActionResult CreateBedroom([FromBody] Bedroom bedroom)
        {
            try
            {
                _service.InsertBedroom(bedroom);
                return Created("Quarto criado", bedroom);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
