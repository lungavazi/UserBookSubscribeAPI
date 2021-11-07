using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserBookSubscribeAPI.Models.DTO;
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
        public IActionResult Get(string id)
        {
            long bookId;
            if (!long.TryParse(id, out bookId))
            {
                return BadRequest("Book does not exist.");
            }
            var bookResult = _userBookManager.GetBookById(bookId);
            if (bookResult.BookId == 0)
            {
                return NotFound("Book does not exist.");
            }
            return Ok(bookResult);
        }

        [HttpPost]
        public IActionResult Add(BookAddDTO bookDTO)
        {
            _userBookManager.AddBook(bookDTO);
            return Ok("Book Created");
        }
    }
}
