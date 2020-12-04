using System;
using apihotelcap.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using apihotelcap.Domain.RequestModels.BedroomRequests;
using Microsoft.AspNetCore.Authorization;

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

        // GET By Id
        /// <summary>
        /// Lista um quarto por Id
        /// </summary>
        /// <param name="Id"></param>/>      
        /// <returns>Uma Lista de quarto por Id</returns>
        /// <response code="200">Retorna que a operação foi retornada</response>
        /// <response code="400">Se a operação não for criada</response>  
        [HttpGet("getById")]
        [Authorize(Roles = "ADM,USER")]
        public IActionResult GetBedroomById([FromQuery] int Id)
        {
            try
            {
                var result = _service.GetBedroomById(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET By Id
        /// <summary>
        /// Lista um quarto pelo IdBedroomType
        /// </summary>
        /// <param name="IdBedroomType"></param>/>      
        /// <returns>Uma Lista de quartos pelo IdBedroomType</returns>
        /// <response code="200">Retorna que a operação foi retornada</response>
        /// <response code="400">Se a operação não for criada</response>  
        [HttpGet("getByIdBedroomType")]
        [Authorize(Roles = "ADM,USER")]
        public IActionResult GetBedroomByIdBedroomType([FromQuery] int IdBedroomType)
        {
            try
            {
                var result = _service.GetBedroomByIdBedroomType(IdBedroomType);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
        [Authorize(Roles = "ADM,USER")]
        public IActionResult CreateBedroom([FromBody] BedroomCreateRequest bedroom)
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

        // PATCH 
        /// <summary>
        /// Realiza a atualização da situation
        /// </summary>
        /// <param name="bedroomUpdate"></param>/>   
        /// <param name="Id"></param>/>      
        /// <returns>Um novo quarto criado</returns>
        /// <response code="200">Retorna que a operação foi criada</response>
        /// <response code="400">Se a operação não for criada</response>  
        [HttpPatch]
        [Authorize(Roles = "ADM,USER")]
        public IActionResult UpdateSituation([FromBody] BedroomUpdateRequest bedroomUpdate, [FromQuery] int Id)
        {
            try
            {
                var result = _service.UpdateSituation(bedroomUpdate, Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
