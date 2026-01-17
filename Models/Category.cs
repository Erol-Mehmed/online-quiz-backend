using System.ComponentModel.DataAnnotations;

namespace OnlineQuizSystem.Models;

public class Category
{
  public int Id { get; set; }

  [MaxLength(250)]
  public required string Name { get; set; }
  public required List<Question> Questions { get; set; }
  
  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
}
