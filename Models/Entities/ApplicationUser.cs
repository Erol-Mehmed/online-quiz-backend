using System.ComponentModel.DataAnnotations;

namespace OnlineQuiz.Api.Models.Entities;
using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
  [MaxLength(100)]
  public string? FirstName { get; set; }
  [MaxLength(100)]
  public string? LastName { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime? UpdatedAt { get; set; }
}
