using System.ComponentModel.DataAnnotations;

namespace OnlineQuizSystem.Models;

public class Category
{
  public int Id { get; set; }

  [MaxLength(250)]
  public required string Name { get; set; }
  public List<Question> Questions { get; set; } = new();
  
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime? UpdatedAt { get; set; }
}
