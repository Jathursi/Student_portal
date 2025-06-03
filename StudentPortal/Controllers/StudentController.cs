using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;
using StudentPortal.Web.ViewData;

namespace StudentPortal.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public StudentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            var Student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                Subscribed = viewModel.Subscribed,
            };
            await dbContext.Students.AddAsync(Student);
            await dbContext.SaveChangesAsync();
            return View();
        }

        [HttpGet]
        // // this is to Read from backend
        // public async Task<IActionResult> List()
        // {
        //     // var Student = await dbContext.Students.ToListAsync();
        //     // return View(Student);
        // }

        // Comment it after connect
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        // [HttpGet]
        // public async Task<IActionResult> Edit(Guid id)
        // {
        //     var student = await dbContext.Students.FindAsync(id);
        //     return View();
        // }
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student = await dbContext.Students.FindAsync(viewModel.Id);
            if (student is not null)
            {
                student.Name = viewModel.Name;
                student.Email = viewModel.Email;
                student.PhoneNumber = viewModel.PhoneNumber;
                student.Subscribed = viewModel.Subscribed;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Student");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Student viewModel)
        {
            //Try this if not worked
            // var student = await dbContext.Students.FindAsync(viewModel.Id);
            // Try this
            var student = await dbContext.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);
                
            if (student is not null)
            {
                dbContext.Students.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Student");
        }
    }
}