namespace OnlineQuizSystem.Models;

public class Quiz
{
  public int Id { get; set; }
  public int CategoryId { get; set; }
  
  public required string Title { get; set; }
  public required string Description { get; set; }
  public required string Category { get; set; }
}
