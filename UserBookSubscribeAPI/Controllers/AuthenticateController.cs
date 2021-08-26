using Microsoft.AspNetCore.Mvc;
using UserBookSubscribeAPI.Manager;

namespace UserBookSubscribeAPI.Controllers
{
    public class AuthenticateController: Controller
    {
        private IUserBookManager _userBookManager;
        public AuthenticateController(IUserBookManager userBookManager)
        {
            _userBookManager = userBookManager;
        }

        [HttpPost]
        [Route("usersubscribeApi/[controller]/{username}/{password}")]
        public IActionResult Get(string username, string password)
        {
            var userDTO = _userBookManager.AuthenticateUser(username, password);
            if (!string.IsNullOrWhiteSpace(userDTO.Token))
            {
                return Ok(userDTO);
            }
            return BadRequest("User details are not correct or the user does not exist.");
        }
    }
}
