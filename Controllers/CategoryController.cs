using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineQuizSystem.Data;
using OnlineQuizSystem.Models;

namespace OnlineQuizSystem.Controllers;

public class CategoryController : Controller
{
  private readonly ApplicationDbContext _context;
  
  public CategoryController(ApplicationDbContext context)
  {
    _context = context;
  }
  
  public async Task<IActionResult> Index()
  {
    var categories = await _context.Categories.ToListAsync();
    
    return Ok(categories);

    // return View(categories);
  }

  public IActionResult Create()
  {
    return View();
  }

  // Temporarily removed
  // [ValidateAntiForgeryToken]
  [HttpPost]
  public async Task<IActionResult> Create([FromBody] Category category)
  {
    try
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _context.Categories.Add(category);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(Index), category);
    }
    catch (Exception error)
    {
      Console.WriteLine(error);
    }

    return Empty;
    // return View(category);
  }
}
