using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetBooksDto>>> GetBooks()
    {
        var books = await _bookService.GetBooksAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetBookDto>> GetBookById(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);

        if (book == null)
            return NotFound();

        return Ok(book);
    }

    [HttpPost]
    public async Task<ActionResult<GetBookDto>> CreateBook(CreateBookDto createBookDto)
    {
        if (!Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development"))
            return Forbid();
            
        var created = await _bookService.CreateBookAsync(createBookDto);

        var createdbook = await _bookService.GetBookByIdAsync(created.Id);
        return CreatedAtAction(nameof(GetBookById), new { id = createdbook.Id }, createdbook);
    }
}
