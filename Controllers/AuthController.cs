using Microsoft.AspNetCore.Mvc;

namespace OnlineQuiz.Api.Controllers;

public class AuthController : Controller
{
  // GET
  public IActionResult Index()
  {
    return View();
  }
}