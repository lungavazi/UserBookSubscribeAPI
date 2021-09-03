using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserBookSubscribeAPI.Manager;

namespace UserBookSubscribeAPI.Controllers
{
    [ApiController]
    [Route("usersubscribeApi/[controller]")]
    [Authorize]
    public class BookSubscriptionsController: ControllerBase
    {
        private IUserBookManager _userBookManager;

        public BookSubscriptionsController(IUserBookManager userBookManager)
        {
            _userBookManager = userBookManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userBookManager.BookSubscriptions());
        }
    }
}
