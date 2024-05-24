using AmoebaApp.DAL;
using AmoebaApp.Models.Employee;
using AmoebaApp.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AmoebaApp.Controllers
{
    public class HomeController(AmoebaDbContext _context) : Controller
    {
        public async Task<IActionResult> Index(GetEmployeeVM vm)
        { var data=await _context.Employees.Select(t=>new GetEmployeeVM 
        {
        Description = t.Description,
        Facebook = t.Facebook,
        Id = t.Id,
        ImageUrl = t.ImageUrl,
        Instagram=t.Instagram,
        LinkedIn = t.LinkedIn,
        Name = t.Name,
        Position = t.Position,
        Twitter=t.Twitter,
        }).ToListAsync();
            return View(data);
        }
    }
}
