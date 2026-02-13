using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineQuizSystem.Data;
using OnlineQuizSystem.Models;

namespace OnlineQuizSystem.Controllers.Admin;

[Authorize(Roles = "Admin")]
[Route("admin/categories")]
public class AdminCategoryController : Controller
{
  private readonly ApplicationDbContext _context;
  
  public AdminCategoryController(ApplicationDbContext context)
  {
    _context = context;
  }

  [HttpGet("")]
  public async Task<IActionResult> Index()
  {
    var categories = await _context.Categories.ToListAsync();
    
    return View(categories);
  }
  
  // Create ----------------------------------------
  public IActionResult Create()
  {
    return View();
  }
  
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Create(Category category)
  {
    if (!ModelState.IsValid)
      return View(category);

    _context.Add(category);
    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Index));
  }
  
  // Edit ------------------------------------------
  public async Task<IActionResult> Edit(int id)
  {
    var category = await _context.Categories.FindAsync(id);
    if (category == null) return NotFound();

    return View(category);
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Edit(int id, Category category)
  {
    if (id != category.Id) return NotFound();

    if (!ModelState.IsValid)
      return View(category);

    _context.Update(category);
    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Index));
  }

  // Delete ----------------------------------------
  public async Task<IActionResult> Delete(int id)
  {
    var category = await _context.Categories.FindAsync(id);
    if (category == null) return NotFound();

    _context.Categories.Remove(category);
    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Index));
  }
}