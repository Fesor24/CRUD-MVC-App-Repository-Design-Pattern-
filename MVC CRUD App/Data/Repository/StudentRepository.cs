using Microsoft.EntityFrameworkCore;
using MVC_CRUD_App.Data.Interface;
using MVC_CRUD_App.Models;

namespace MVC_CRUD_App.Data.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(Student student)
        {
            _context.Remove(student);
            _context.SaveChanges();
        }

        public IEnumerable<Student> GetAllStudents
        {
            get
            {
                return _context.Students.ToList();
            }
        }

        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
    }
}
