using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserBookSubscribeAPI.Entities.DTO;
using UserBookSubscribeAPI.Manager;

namespace UserBookSubscribeAPI.Controllers
{
    [ApiController]
    [Route("usersubscribeApi/[controller]")]
    [Authorize]
    public class BookController: ControllerBase
    {
        private IUserBookManager _userBookManager;

        public BookController(IUserBookManager userBookManager)
        {
            _userBookManager = userBookManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userBookManager.GetBooks());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_userBookManager.GetBookById(id));
        }

        [HttpPost]
        public IActionResult Add(BookAddDTO bookDTO)
        {
            _userBookManager.AddBook(bookDTO);
            return Ok("Book Created");
        }
    }
}
