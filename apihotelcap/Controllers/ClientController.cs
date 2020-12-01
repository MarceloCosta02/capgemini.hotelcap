using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apihotelcap.Domain.RequestModels.ClientRequests;
using apihotelcap.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace apihotelcap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {        
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        // GET By Id
        /// <summary>
        /// Lista cliente pelo ID
        /// </summary>
        /// <param name="Id"></param>/>      
        /// <returns>Um cliente pelo Id</returns>
        /// <response code="200">Retorna que a operação foi retornada</response>
        /// <response code="400">Se a operação não for criada</response>  
        [HttpGet]
        public IActionResult GetBedroomTypeById([FromQuery] int Id)
        {
            try
            {
                var result = _service.GetClientById(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST 
        /// <summary>
        /// Cadastra um cliente
        /// </summary>
        /// <param name="client"></param>/>      
        /// <returns>Um novo cliente cadastrado</returns>
        /// <response code="201">Retorna que a operação foi criada</response>
        /// <response code="400">Se a operação não for criada</response>  
        [HttpPost]
        public IActionResult CreateBedroomType([FromBody] ClientCreateRequest client)
        {
            try
            {
                _service.InsertClient(client);
                return Created("Cliente cadastrado", client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
