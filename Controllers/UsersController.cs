using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoggyCare.Repositories;
using DoggyCare.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DoggyCare.Models;
using DoggyCare.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoggyCare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _repository;

        public UsersController(IUsersRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<UserDTO> Get()
        {
            return _repository.GetUsers().Select(user => user.AsDTO());
        }

        [HttpGet("{id}")]
        public ActionResult<UserDTO> GetId(int id)
        {
            var user = _repository.GetUser(id);

            if (user is null)
                return NotFound();

            return user.AsDTO();
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromBody] UserDTO model)
        {
            var user = _repository.GetUser(model.Username, model.Password);

            if (user is null)
                return NotFound(new { message = "User or password invalid" });

            string token = TokenService.CreateToken(user);

            return new
            {
                user = user.AsDTO(),
                token
            };
        }

        [HttpPost]
        [Route("register")]
        public ActionResult<UserDTO> Register([FromBody] UserDTO userDTO)
        {
            User user = new()
            {
                Id = Int32.MaxValue,
                Username = userDTO.Username,
                Password = userDTO.Password,
                Role = userDTO.Role
            };

            _repository.CreateUser(user);

            return CreatedAtAction(nameof(Get), new { user.Id }, user.AsDTO());
        }
    }
}
