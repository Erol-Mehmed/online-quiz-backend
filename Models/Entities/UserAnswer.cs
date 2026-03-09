namespace OnlineQuiz.Api.Models.Entities;

public class UserAnswer
{
  public int Id { get; set; }
  
  public int ResultId { get; set; }
  public Result? Result { get; set; }
  
  public int QuestionId { get; set; }
  public Question? Question { get; set; }
  
  public int SelectedAnswerId { get; set; }
  public Answer? SelectedAnswer { get; set; }
}
