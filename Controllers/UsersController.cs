using System;
using System.Collections.Generic;
using System.Linq;
using EcommerceStoreAPI.Data.Contracts;
using EcommerceStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _repository;

        public UsersController(IUsersRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Users>> GetUsers()
        {
            try
            {
                var users = _repository.GetUsers();
                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Users> GetUserBYId(int id)
        {
            try
            {
                var user = _repository.GetUserById(id);
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult<Users> AddUser([FromBody] Users user)
        {
            try
            {
                _repository.CreateUser(user);
                _repository.SaveChanges();
                return CreatedAtAction(nameof(GetUserBYId), new Users { Id = user.Id }, user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult PutUser([FromBody] Users user)
        {
            try
            {
                var userEdit = _repository.GetUserById(user.Id);
                if (userEdit == null)
                    return NotFound();

                _repository.UpdateUser(userEdit);
                _repository.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("login")]
        public ActionResult<String> LoginUser(string email, string password)
        {
            var valid = _repository.LoginUser(email, password);

            if (!valid)
                return NotFound();
            return Ok("Acceso-consedido");
        }
    }
}