using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineQuiz.Api.Data;

namespace OnlineQuiz.Api.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
  private readonly ApplicationDbContext _context;
  
  public AdminController(ApplicationDbContext context)
  {
    _context = context;
  }

  public IActionResult Index()
  {
    return View();
  }
  
  public IActionResult ManageCategories()
  {
    var categories = _context.Categories.ToList();
    return View(categories);
  }

  public IActionResult ManageQuizzes()
  {
    var quizzes = _context.Quizzes.ToList();
    return View(quizzes);
  }
}
