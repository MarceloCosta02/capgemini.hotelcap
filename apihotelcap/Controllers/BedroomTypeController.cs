using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apihotelcap.Domain.RequestModels.BedroomRequests;
using apihotelcap.Interfaces.Services;
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
        public IActionResult CreateBedroomType([FromBody] BedroomTypeCreateRequest bedroomType)
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

        // GET 
        /// <summary>
        /// Lista todos os tipos de quarto
        /// </summary>
        /// <returns>Uma lista de todos os tipos de quarto</returns>
        /// <response code="200">Retorna que a operação foi retornada</response>
        /// <response code="400">Se a operação não for criada</response>  
        [HttpGet]
        public IActionResult GetAllBedroomsType()
        {
            try
            {
                var result = _service.GetAllBedroomsType();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET By Id
        /// <summary>
        /// Lista um tipo de quarto por Id
        /// </summary>
        /// <param name="Id"></param>/>      
        /// <returns>Uma Lista de um tipo de quarto por Id</returns>
        /// <response code="200">Retorna que a operação foi retornada</response>
        /// <response code="400">Se a operação não for criada</response>  
        [HttpGet("getById")]
        public IActionResult GetBedroomTypeById([FromQuery] int Id)
        {
            try
            {
                var result = _service.GetBedroomTypeById(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
