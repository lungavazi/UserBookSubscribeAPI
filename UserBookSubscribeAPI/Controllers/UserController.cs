using Microsoft.AspNetCore.Mvc;
using UserBookSubscribeAPI.Manager;
using UserBookSubscribeAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;

namespace UserBookSubscribeAPI.Controllers
{
    [ApiController]
    [Route("usersubscribeApi/[controller]")]
    [Authorize]
    public class UserController: ControllerBase
    {
        private readonly IUserBookManager _userBookManager;

        public UserController(IUserBookManager userBookManager)
        {
            _userBookManager = userBookManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
                return Ok(_userBookManager.GetUsers());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            long userId;
            if (!long.TryParse(id, out userId))
            {
                return NotFound("User does not exist.");
            }
            var userResult = _userBookManager.GetUserById(userId);
            if (userResult.UserId == 0)
            {
                return NotFound("User does not exist.");
            }
            return Ok(userResult);
        }

        [HttpPost]
        public IActionResult Add(UserAddDTO userDTO)
        {
            _userBookManager.AddUser(userDTO);
            return Ok("User Created");
        }
    }
}
