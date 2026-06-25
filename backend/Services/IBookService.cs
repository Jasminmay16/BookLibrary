using Shared;
public interface IBookService
{
    /// <summary>
    ///  Gets all books.
    /// </summary>
    /// <returns>A collection of book DTOs.</returns>
    Task<IEnumerable<GetBooksDto>> GetBooksAsync();

    /// <summary>
    ///  Gets a book by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The book DTO if found, otherwise null.</returns>
    Task<GetBookDto?> GetBookByIdAsync(int id);

    /// <summary>
    /// Creates a new book.
    /// </summary>
    /// <param name="createBookDto">The DTO containing the book details.</param>
    /// <returns>The created book DTO.</returns>
    Task<GetBookDto> CreateBookAsync(CreateBookDto createBookDto);
}