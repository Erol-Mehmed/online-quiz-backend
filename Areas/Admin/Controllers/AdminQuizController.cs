using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineQuiz.Api.Data;
using OnlineQuiz.Api.Models.Entities;

namespace OnlineQuiz.Api.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
[Route("admin/quizzes")]
public class AdminQuizController : Controller
{
  private readonly ApplicationDbContext _context;

  public AdminQuizController(ApplicationDbContext context)
  {
    _context = context;
  }

  [HttpGet("")]
  public async Task<IActionResult> Index()
  {
    var quizzes = await _context.Quizzes.Include(q => q.Category).ToListAsync();
    
    return View(quizzes);
  }

  // Create -----------------------------------------
  [HttpGet("create")]
  public IActionResult Create()
  {
    ViewBag.Categories = _context.Categories.ToList();
    
    return View();
  }
  
  [HttpPost("create")]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Create(Quiz quiz)
  {
    if (!ModelState.IsValid)
    {
      ViewBag.Categories = _context.Categories.ToList();
      
      return View(quiz);
    }

    _context.Add(quiz);
    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Index));
  }
  
  // Edit ------------------------------------------
  [HttpGet("edit/{id}")]
  public async Task<IActionResult> Edit(int id)
  {
    var quiz = await _context.Quizzes.FindAsync(id);
    if (quiz == null) return NotFound();
    
    ViewBag.Categories = _context.Categories.ToList();
    
    return View(quiz);
  }

  [HttpPost("edit/{id}")]
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
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Delete(int id)
  {
    var quiz = await _context.Quizzes.FindAsync(id);
    if (quiz == null) return NotFound();
    
    _context.Quizzes.Remove(quiz);
    await _context.SaveChangesAsync();
    
    return RedirectToAction(nameof(Index));
  }
}
