using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserBookSubscribeAPI.Manager;

namespace UserBookSubscribeAPI.Controllers
{
    [ApiController]
    [Route("usersubscribeApi/[controller]")]
    [Authorize]
    public class SubscribeController: ControllerBase
    {
        private IUserBookManager _userBookManager;

        public SubscribeController(IUserBookManager userBookManager)
        {
            _userBookManager = userBookManager;
        }

        [HttpPost]
        public IActionResult Add(int userId, int bookId)
        {
            var results = "";
            _userBookManager.Subscribe(userId, bookId, out results);

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
