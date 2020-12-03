using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apihotelcap.Domain.RequestModels.ClientRequests;
using apihotelcap.Domain.RequestModels.UserRequests;
using apihotelcap.Interfaces.Repository;
using apihotelcap.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace apihotelcap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {        
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        // POST
        /// <summary>
        /// Loga o usuário
        /// </summary>
        /// <param name="userLogin"></param>/>      
        /// <returns>Usuário logado</returns>
        /// <response code="200">Retorna que a operação foi retornada</response>
        /// <response code="400">Se a operação não for criada</response>  
        [AllowAnonymous]
        [HttpPost("login")]
        [Authorize(Roles = "ADM,USER")]
        public IActionResult Login([FromBody] UserLoginRequest userLogin)
        {
            try
            {
                var result = _service.Login(userLogin);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST 
        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="user"></param>/>      
        /// <returns>Um novo usuário cadastrado</returns>
        /// <response code="201">Retorna que a operação foi criada</response>
        /// <response code="400">Se a operação não for criada</response>  
        [HttpPost("createUser")]
        [Authorize(Roles = "ADM")]
        public IActionResult CreateUser([FromBody] UserCreateRequest user)
        {
            try
            {
                _service.CreateUser(user);
                return Created("Usuário cadastrado", user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
