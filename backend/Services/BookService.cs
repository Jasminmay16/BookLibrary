using Microsoft.EntityFrameworkCore;
using Shared;

public class BookService : IBookService
{
    private readonly AppDbContext _dbContext;

    public BookService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<GetBooksDto>> GetBooksAsync()
    {
        return await _dbContext.Books
            .Select(book => new GetBooksDto
            {
                Id = book.Id,
                Rank = book.Rank,
                Title = book.Title,
                Author = book.Author,
                Year = book.Year,
                Description = book.Description,
                ImageUrl = book.ImageUrl
            })
            .ToListAsync();
    }

    public async Task<GetBookDto?> GetBookByIdAsync(int id)
    {
        var book = await _dbContext.Books.FindAsync(id);

        if (book == null) return null;

        return new GetBookDto
        {
            Id = book.Id,
            Rank = book.Rank,
            Title = book.Title,
            Author = book.Author,
            Year = book.Year,
            Description = book.Description,
            ImageUrl = book.ImageUrl
        };
    }

    public async Task<GetBookDto> CreateBookAsync(CreateBookDto createBookDto)
    {
        var book = new Book
        {
            Title = createBookDto.Title,
            Author = createBookDto.Author,
            Year = createBookDto.Year,
            Description = createBookDto.Description,
            ImageUrl = createBookDto.ImageUrl
        };

        _dbContext.Books.Add(book);
        await _dbContext.SaveChangesAsync();

        return new GetBookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Year = book.Year,
            Description = book.Description,
            ImageUrl = book.ImageUrl
        };
    }     
}