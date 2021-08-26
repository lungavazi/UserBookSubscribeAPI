using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserBookSubscribeAPI.Manager;

namespace UserBookSubscribeAPI.Controllers
{
    [ApiController]
    [Route("usersubscribeApi/[controller]")]
    [Authorize]
    public class UnsubscribeController: ControllerBase
    {
        private readonly IUserBookManager _userBookManager;
        public UnsubscribeController(IUserBookManager userBookManager)
        {
            _userBookManager = userBookManager;
        }

        [HttpPost]
        public IActionResult Remove(int userId, int bookId)
        {
            var results = "";
            _userBookManager.Unsubscribe(userId, bookId, out results);

            if (results.Contains("subscribed"))
            {
                return Ok(results);
            }
            else
            {
                return BadRequest(results);
            }
        }
    }
}
