using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD_App.Data.Interface;
using MVC_CRUD_App.Models;

namespace MVC_CRUD_App.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IStudentRepository _studentRepository;

        public StudentController(AppDbContext context, IStudentRepository studentRepository)
        {
            _context = context;
            _studentRepository = studentRepository;
        }
        public IActionResult Index()
        {
            var allStudents = _studentRepository.GetAllStudents;
            return View(allStudents);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student model)
        {
            if (ModelState.IsValid)
            {
                model.RegistrationDate = DateTime.Now;
                _studentRepository.CreateStudent(model);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }

            var result = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Student model)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.UpdateStudent(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var result = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }

            var result = _context.Students.Find(id);
            if(result== null)
            {
                return NotFound();
            }

            _studentRepository.DeleteStudent(result);
            return RedirectToAction(nameof(Index));
        }
    }
}
