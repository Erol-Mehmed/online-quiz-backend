using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineQuiz.Api.Data;

namespace OnlineQuiz.Api.Controllers;

[Authorize]
public class QuizController : Controller
{
  private readonly ApplicationDbContext _context;

  public QuizController(ApplicationDbContext context)
  {
    _context = context;
  }

  public async Task<IActionResult> Index(int? categoryId)
  {
    var quizzes = _context.Quizzes.AsQueryable();
    
    if (categoryId != null)
      quizzes = quizzes.Where(q => q.CategoryId == categoryId);
    
    return View(await quizzes.ToListAsync());
  }
}
