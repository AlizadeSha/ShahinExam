using AmoebaApp.DAL;
using AmoebaApp.Models.Employee;
using AmoebaApp.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmoebaApp.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class EmployeeController(AmoebaDbContext _context,IWebHostEnvironment _env) : Controller
    {
       
        public async Task<IActionResult> Index()
        {
            var data = await _context.Employees.Select(e => new GetEmployeeVM
            {
                Name = e.Name,
                Description = e.Description,
                Facebook = e.Facebook,
                Id = e.Id,
                ImageUrl = e.ImageUrl,
                Instagram = e.Instagram,
                LinkedIn = e.LinkedIn,
                Position = e.Position,
                Twitter = e.Twitter,
            }).ToListAsync();

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

          string filename=Guid.NewGuid().ToString()+vm.ImageUrl.FileName;
            string path = Path.Combine(_env.WebRootPath, "assets", "img", filename);
            FileStream file = new FileStream(path, FileMode.Create);
            vm.ImageUrl.CopyToAsync(file);
               

            //MEllim url nen yazmaq asandi biilrem onu sadece erroru tapa bilmedim dusunduyum qeder gonderilem imgurl tipleri ferlidi deye problem yaranir ama update edende 
            //fayl adi yaratmaq lazmdi deyesen ne qeder eledim tapa bilmedim




            Employee employee = new Employee
            {
                Twitter = vm.Twitter,
                Position = vm.Position,
                Description = vm.Description,
                Facebook = vm.Facebook,
                ImageUrl = filename,
                Instagram = vm.Instagram,
                LinkedIn = vm.LinkedIn,
                Name = vm.Name,
            };

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null && id < 1) { return BadRequest(); }

            Employee employee = await _context.Employees.FirstOrDefaultAsync(s => s.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            UpdateEmployeeVM updatevm = new UpdateEmployeeVM
            {
                Name = employee.Name,
                Twitter = employee.Twitter,
                LinkedIn = employee.LinkedIn,
                ImageUrl = employee.ImageUrl,
                Instagram = employee.Instagram,
                Description = employee.Description,
                Facebook = employee.Facebook,
                Position = employee.Position,
            };  



            


            return View(updatevm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateEmployeeVM updateEmployeeVM, int? id)
        {
            if (id == null && id < 1) { return BadRequest(); }
            Employee existed = await _context.Employees.FirstOrDefaultAsync(s => s.Id == id);

            if (existed == null)
            {
                return NotFound();
            }

            existed.Facebook = updateEmployeeVM.Facebook;
            existed.Twitter = updateEmployeeVM.Twitter;
            existed.LinkedIn = updateEmployeeVM.LinkedIn;
            existed.Name = updateEmployeeVM.Name;
            existed.Position = updateEmployeeVM.Position;
            //existed.ImageUrl = updateEmployeeVM.ImageUrl;
            existed.Description = updateEmployeeVM.Description;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
    }
}

