using System.ComponentModel.DataAnnotations;

namespace OnlineQuizSystem.Models;
using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
  [MaxLength(250)]
  public string? FirstName { get; set; }
  [MaxLength(250)]
  public string? LastName { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime? UpdatedAt { get; set; }
}
