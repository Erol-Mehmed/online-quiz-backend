using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineQuiz.Api.Models.DTOs.Auth;
using OnlineQuiz.Api.Models.Entities;

namespace OnlineQuiz.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
  private readonly required UserManager<ApplicationUser> _userManager;
  private readonly required SignInManager<ApplicationUser> _signInManager;

  public AuthController(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager)
  {
    _userManager = userManager;
    _signInManager = signInManager;
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register(RegisterDto dto)
  {
    var user = new ApplicationUser
    {
      UserName = dto.Email,
      Email = dto.Email
    };

    var result = await _userManager.CreateAsync(user, dto.Password);

    if (!result.Succeeded)
      return BadRequest(result.Errors);

    await _signInManager.SignInAsync(user, isPersistent: false);

    return Ok(new { message = "User registered" });
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login(
  {
  }
}