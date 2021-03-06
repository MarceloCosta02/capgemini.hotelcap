﻿using System;
using apihotelcap.Domain.RequestModels.ClientRequests;
using apihotelcap.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apihotelcap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OccupationController : ControllerBase
    {
        private readonly IOccupationService _service;

        public OccupationController(IOccupationService service)
        {
            _service = service;
        }

        // POST 
        /// <summary>
        /// Cadastra uma ocupação
        /// </summary>
        /// <param name="occupation"></param>/>      
        /// <returns>Uma nova ocupação cadastrada</returns>
        /// <response code="201">Retorna que a operação foi criada</response>
        /// <response code="400">Se a operação não for criada</response>  
        [HttpPost]
        [Authorize(Roles = "ADM,USER")]
        public IActionResult CreateOccupation([FromBody] OccupationCreateRequest occupation)
        {
            try
            {
                _service.InsertOccupation(occupation);
                return Created("Ocupação cadastrada", occupation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
