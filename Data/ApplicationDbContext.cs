using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineQuizSystem.Models;

namespace OnlineQuizSystem.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options) {}
  public DbSet<Quiz> Quizzes { get; set; }
  public DbSet<Question> Questions { get; set; }
  public DbSet<Answer> Answers { get; set; }
  public DbSet<Category> Categories { get; set; }
  public DbSet<Result>  Results { get; set; }
  public DbSet<UserAnswer> UserAnswers { get; set; }
  
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    
    modelBuilder.Entity<Answer>()
    .HasOne(a => a.Question)
      .WithMany(q => q.Answers)
      .HasForeignKey(a => a.QuestionId)
      .OnDelete(DeleteBehavior.Cascade);
    
    modelBuilder.Entity<Question>()
      .HasOne(q => q.CorrectAnswer)
      .WithMany()
      .HasForeignKey(q => q.CorrectAnswerId)
      .OnDelete(DeleteBehavior.Restrict);
  }
}
