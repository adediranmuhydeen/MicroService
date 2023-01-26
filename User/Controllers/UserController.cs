using Microsoft.AspNetCore.Mvc;
using User.Model;
using User.Services;

namespace User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _service.GetUserList();

            return Ok(users);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var user = _service.GetUserById(id);
            if (user == null)
            {
                return BadRequest($"User with ID {id} was not found");
            }
            return Ok(user);
        }


        [HttpPost]
        public IActionResult Post([FromBody] AppUser appUser)
        {
            var user = _service.AddUser(appUser);
            if (user == null)
            {
                return BadRequest($"{appUser.FullName} was not registered");
            }
            return Ok(user);
        }

        [HttpPut]

        public IActionResult Put([FromBody] AppUser appUser)
        {
            var user = _service.UpdateUser(appUser);
            if (user == null)
            {
                return BadRequest($"{appUser.FullName} was not updated");
            }
            return Ok(user);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _service.DeleteUser(id);
            if (!result)
            {
                return BadRequest($"User with ID {id} was not found");
            }
            return Ok(result);
        }
    }
}
