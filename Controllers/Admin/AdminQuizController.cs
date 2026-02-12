using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineQuizSystem.Models;
using OnlineQuizSystem.Data;

namespace OnlineQuizSystem.Controllers.Admin;

[Authorize(Roles = "Admin")]
public class AdminQuizController : Controller
{
  private readonly ApplicationDbContext _context;

  public AdminQuizController(ApplicationDbContext context)
  {
    _context = context;
  }
  
  [HttpGet("")]
  public IActionResult Index()
  {
    return View();
  }

  // Create -----------------------------------------
  public IActionResult Create()
  {
    return View();
  }
  
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Create(Quiz quiz)
  {
    if (!ModelState.IsValid)
      return View(quiz);

    _context.Add(quiz);
    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Index));
  }
  
  // Edit ------------------------------------------
  public async Task<IActionResult> Edit(int id)
  {
    var quiz = await _context.Quizzes.FindAsync(id);
    if (quiz == null) return NotFound();
    
    return View(quiz);
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Edit(int id, Quiz quiz)
  {
    if (id != quiz.Id) return NotFound();

    if (!ModelState.IsValid)
      return View(quiz);

    _context.Update(quiz);
    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Index));
  }
  
  // Delete ---------------------------------------
  public async Task<IActionResult> Delete(int id)
  {
    var quiz = await _context.Quizzes.FindAsync(id);
    if (quiz == null) return NotFound();
    
    _context.Quizzes.Remove(quiz);
    await _context.SaveChangesAsync();
    
    return RedirectToAction(nameof(Index));
  }
}
