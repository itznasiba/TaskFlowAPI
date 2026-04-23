using Microsoft.AspNetCore.Mvc;
using YoutubeAPI.Business.Services;
using YoutubeAPI.Core.User;

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
        public IActionResult UpdateProfile(int id, UserSaveDto user)
        {
            var existingUser = _userService.GetById(id);
            if (existingUser == null) 
            {
                return new NotFoundResult();
            }
            try
            {
                _userService.UpdateProfile(id, user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
