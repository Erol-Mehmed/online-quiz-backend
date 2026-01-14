namespace OnlineQuizSystem.Models;

public class Quiz
{
  public int Id { get; set; }
  
  public int CategoryId { get; set; }
  public Category? Category { get; set; }
  
  public required string Title { get; set; }
  public required string Description { get; set; }
  public List<UserAnswer>? UserAnswers { get; set; }

  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
}
