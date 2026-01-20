using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using OnlineQuizSystem.Data;

namespace OnlineQuizSystem.Controllers;

public class QuizController : Controller
{
  private readonly ApplicationDbContext _context;

  public QuizController(ApplicationDbContext context)
  {
    _context = context;
  }

  public IActionResult Index()
  {
    var quizzes = _context.Quizzes.ToList();
    
    return View(quizzes);
  }
}
