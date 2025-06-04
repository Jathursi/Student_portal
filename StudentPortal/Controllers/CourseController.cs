using  Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;
using StudentPortal.Web.ViewData;
using Microsoft.AspNetCore.Identity;

namespace StudentPortal.Web.Controllers
{
    public class CourseController : Controller
    {
        //inject the database context into your controller
        private readonly ApplicationDbContext dbContext;

        public CourseController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult AddCourse()
        {
            return View();
        }
        // Example controller action
        [HttpPost]
        public async Task<IActionResult> Add(AddCourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                byte[]? imageBytes = null;
                string? mimeType = null;

                if (model.ImageData != null && model.ImageData.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await model.ImageData.CopyToAsync(ms);
                        imageBytes = ms.ToArray();
                    }
                    mimeType = model.ImageData.ContentType;
                }

                // Save imageBytes and mimeType to your Course entity as needed

                // ...rest of your logic...
            }

            return View(model);
        }
        public IActionResult ListCourse()
        {
            return View();
        }
    }
}