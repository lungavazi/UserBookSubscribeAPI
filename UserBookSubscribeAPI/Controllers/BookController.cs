using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserBookSubscribeAPI.Models.DTO;
using UserBookSubscribeAPI.Manager;

namespace UserBookSubscribeAPI.Controllers
{
    [ApiController]
    [Route("usersubscribeApi/[controller]")]
    //[Authorize]
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
            int bookId;
            if (!int.TryParse(id, out bookId))
            {
                return NotFound("Book does not exist.");
            }
            return Ok(_userBookManager.GetBookById(bookId));
        }

        [HttpPost]
        public IActionResult Add(BookAddDTO bookDTO)
        {
            _userBookManager.AddBook(bookDTO);
            return Ok("Book Created");
        }
    }
}
