using System.ComponentModel.DataAnnotations;

namespace OnlineQuizSystem.Models;

public class Answer
{
  public int Id { get; set; }
  
  public int QuestionId { get; set; }
  public Question? Question { get; set; }
  
  [MaxLength(500)]
  public required string Text { get; set; }
  
  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
}
