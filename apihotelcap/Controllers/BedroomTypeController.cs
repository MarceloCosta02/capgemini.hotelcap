using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apihotelcap.Interfaces.Services;
using apihotelcap.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace apihotelcap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BedroomTypeController : ControllerBase
    {
        private readonly IBedroomTypeService _service;

        public BedroomTypeController(IBedroomTypeService service)
        {
            _service = service;
        }

        // POST 
        /// <summary>
        /// Cria um tipo de quarto
        /// </summary>
        /// <param name="bedroomType"></param>/>      
        /// <returns>Um novo tipo de quarto criado</returns>
        /// <response code="201">Retorna que a operação foi criada</response>
        /// <response code="400">Se a operação não for criada</response>  
        [HttpPost]
        public IActionResult CreateBedroomType([FromBody] BedroomType bedroomType)
        {
            try
            {
                _service.InsertBedroomType(bedroomType);
                return Created("Tipo de Quarto criado", bedroomType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
