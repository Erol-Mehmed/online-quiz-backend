using System.ComponentModel.DataAnnotations;

namespace OnlineQuizSystem.Models;

public class Result
{
  public int Id { get; set; }
  
  [MaxLength(500)]
  public required string UserId { get; set; }
  public ApplicationUser? User { get; set; }
  
  [MaxLength(500)]
  public required string QuizId { get; set; }
  public Quiz? Quiz { get; set; }
  
  public int Score { get; set; }
  public DateTime CompletedAt { get; set; }
}
