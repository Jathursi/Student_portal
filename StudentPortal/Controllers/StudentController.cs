using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;
using StudentPortal.Web.ViewData;
using Microsoft.AspNetCore.Identity;
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
        // [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel); // Return view with errors

            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                Subscribed = viewModel.Subscribed,
                Entrollment = viewModel.Entrollment, 
                // password = viewModel.password 
            };
            var hasher = new PasswordHasher<Student>();
            student.password = hasher.HashPassword(student, viewModel.password);

            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Student"); // Optional: redirect to list
        }

        // public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        // {
        //     var Student = new Student
        //     {
        //         Name = viewModel.Name,
        //         Email = viewModel.Email,
        //         PhoneNumber = viewModel.PhoneNumber,
        //         Subscribed = viewModel.Subscribed,
        //     };
        //     await dbContext.Students.AddAsync(Student);
        //     await dbContext.SaveChangesAsync();
        //     return View();
        // }

        [HttpGet]
        // this is to Read from backend
        public async Task<IActionResult> List()
        {
            var Student = await dbContext.Students.ToListAsync();
            return View(Student);
        }

        // Comment it after connect
        // [HttpGet]
        // public IActionResult List()
        // {
        //     return View();
        // }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();  // or return a view with an error message
            }
            return View(student);  // pass the student to the view
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
                student.Entrollment = viewModel.Entrollment;
                // student.password = viewModel.password;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Student");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var student = await dbContext.Students.FindAsync(Id);
            if (student != null)
            {
                dbContext.Students.Remove(student);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }
    }
}