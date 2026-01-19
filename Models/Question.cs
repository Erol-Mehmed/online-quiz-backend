using System.ComponentModel.DataAnnotations;

namespace OnlineQuizSystem.Models;

public class Question
{
  public int Id { get; set; }
  
  public int CategoryId { get; set; }
  public Category? Category { get; set; }

  public int CorrectAnswerId { get; set; }
  public Answer? CorrectAnswer { get; set; }

  [MaxLength(500)]
  public required string Text { get; set; }
  public List<Answer> Answers { get; set; } = new();
  
  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
}
