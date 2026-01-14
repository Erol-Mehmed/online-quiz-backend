namespace OnlineQuizSystem.Models;

public class Category
{
  public int Id { get; set; }

  public required string Name { get; set; }
  public required List<Question> Questions { get; set; }
  
  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
}
