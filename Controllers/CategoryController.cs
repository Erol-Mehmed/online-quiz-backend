using Microsoft.AspNetCore.Mvc;
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

  public IActionResult Index()
  {
    var categories = _context.Categories.ToList();
    
    return View(categories);
  }

  public IActionResult Create()
  {
    return View();
  }

  // Temporarily removed
  // [ValidateAntiForgeryToken]
  [HttpPost]
  public IActionResult Create([FromBody] Category category)
  {
    try
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      
      _context.Categories.Add(category);
      _context.SaveChanges();
      
      Console.WriteLine("Category created successfully");
      
      // return RedirectToAction(nameof(Index));
    }
    catch (Exception error)
    {
      Console.WriteLine(error);
    }

    return Empty;
    // return View(category);
  }
}
