using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineQuizSystem.Data;

namespace OnlineQuizSystem.Controllers;

[Authorize]
public class QuizController : Controller
{
  private readonly ApplicationDbContext _context;

  public QuizController(ApplicationDbContext context)
  {
    _context = context;
  }

  public async Task<IActionResult> Index()
  {
    var quizzes = await _context.Quizzes.ToListAsync();
    
    return View(quizzes);
  }
}
