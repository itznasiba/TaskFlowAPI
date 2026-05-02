using Microsoft.AspNetCore.Mvc;
using TaskAPI.Business.Services;
using TaskAPI.Core.Exceptions;
using TaskAPI.Core.User;

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
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProfile(int id, UserSaveDto user)
        {
            _userService.UpdateProfile(id, user);
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(UserSaveDto user)
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
