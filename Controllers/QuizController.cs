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
  
  // [ValidateAntiForgeryToken]
  [HttpPost]
  public async Task<IActionResult> Create([FromBody] Quiz quiz)
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
