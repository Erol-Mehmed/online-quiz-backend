using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineQuiz.Api.Data;

namespace OnlineQuiz.Api.Controllers.Api;

public class CategoryController : ControllerBase
{
  private readonly ApplicationDbContext _context;
  
  public CategoryController(ApplicationDbContext context)
  {
    _context = context;
  }
  
  public async Task<IActionResult> Index()
  {
    var categories = await _context.Categories.ToListAsync();

    return View(categories);
  }
}
