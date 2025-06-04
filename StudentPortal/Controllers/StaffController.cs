using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;
using StudentPortal.Web.ViewData;
using Microsoft.AspNetCore.Identity;

namespace StudentPortal.Web.Controllers
{
    public class StaffController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public StaffController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel); // Return view with errors

            var staff = new Staff
            {
                Sta_Name = viewModel.Sta_Name,
                Sta_Email = viewModel.Sta_Email,
                Sta_PhoneNumber = viewModel.Sta_PhoneNumber,
                Sta_Subscribed = viewModel.Sta_Subscribed,
                Sta_Entrollment = viewModel.Sta_Entrollment,
                // Sta_password = viewModel.password 
            };
            var hasher = new PasswordHasher<Staff>();
            staff.Sta_password = hasher.HashPassword(staff, viewModel.Sta_password);

            await dbContext.Staffs.AddAsync(staff);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("ListStaff", "Staff"); // Optional: redirect to list
        }
        [HttpGet]
        public async Task<IActionResult> ListStaff()
        {
            var staff = await dbContext.Staffs.ToListAsync();
            return View(staff);
        }
        [HttpGet]
        public async Task<IActionResult> EditStaff(Guid id)
        {
            var staff = await dbContext.Staffs.FindAsync(id);
            if (staff == null)
            {
                return NotFound();  // or return a view with an error message
            }
            return View(staff);  // pass the student to the view
        }


        [HttpPost]
        public async Task<IActionResult> EditStaff(Staff viewModel)
        {
            var staff = await dbContext.Staffs.FindAsync(viewModel.Id);
            if (staff is not null)
            {
                staff.Sta_Name = viewModel.Sta_Name;
                staff.Sta_Email = viewModel.Sta_Email;
                staff.Sta_PhoneNumber = viewModel.Sta_PhoneNumber;
                staff.Sta_Subscribed = viewModel.Sta_Subscribed;
                staff.Sta_Entrollment = viewModel.Sta_Entrollment;
                // student.password = viewModel.password;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("ListStaff", "Staff");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var staff = await dbContext.Staffs.FindAsync(Id);
            if (staff != null)
            {
                dbContext.Staffs.Remove(staff);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("ListStaff");
        }
    }
}