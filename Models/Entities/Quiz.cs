using System.ComponentModel.DataAnnotations;

namespace OnlineQuizSystem.Models;

public class Quiz
{
  public int Id { get; set; }
  
  public int CategoryId { get; set; }
  public Category? Category { get; set; }
  
  [MaxLength(150)]
  public required string Title { get; set; }
  [MaxLength(1000)]
  public required string Description { get; set; }

  public List<UserAnswer> UserAnswers { get; set; } = new();
  public List<Result> Results { get; set; } = new();

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime? UpdatedAt { get; set; }
}
