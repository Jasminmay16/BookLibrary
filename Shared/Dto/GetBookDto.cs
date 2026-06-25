namespace Shared;

public class GetBookDto
{
    public int Id { get; set; }
    public int Rank { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public int Year { get; set; }
    public required string Description { get; set; }
    public string ImageUrl { get; set; } = "WorkInProgress.png";
}
