using MVC_CRUD_App.Models;

namespace MVC_CRUD_App.Data.Interface
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents { get; }

        void CreateStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);
    }
}
