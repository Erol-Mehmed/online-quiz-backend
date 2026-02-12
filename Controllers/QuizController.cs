using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineQuizSystem.Data;
using OnlineQuizSystem.Models;

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
  
  [Authorize(Roles = "Admin")]
  public IActionResult Create()
  {
    return View();
  }
  
  [Authorize(Roles = "Admin")]
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Create(Quiz quiz)
  {
    try
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      
      _context.Quizzes.Add(quiz);
      await _context.SaveChangesAsync();
      
      return CreatedAtAction(nameof(Index), quiz);
    }
    catch(Exception error)
    {
      Console.WriteLine(error);
      
      return BadRequest(error);
    }
  }
}
