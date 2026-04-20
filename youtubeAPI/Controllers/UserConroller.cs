using Microsoft.AspNetCore.Mvc;
using youtubeAPI.Core.Entities;
using YoutubeAPI.Business.Services;

namespace youtubeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return new NotFoundResult();
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProfile(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            _userService.UpdateProfile(user);
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(User user)
        {
            _userService.Add(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }


    }
}
