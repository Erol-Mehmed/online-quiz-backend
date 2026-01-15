namespace OnlineQuizSystem.Models;

public class Result
{
  public int Id { get; set; }
  
  public required string UserId { get; set; }
  public ApplicationUser? User { get; set; }
  
  public required string QuizId { get; set; }
  public Quiz? Quiz { get; set; }
  
  public int Score { get; set; }
  public DateTime CompletedAt { get; set; }
}
