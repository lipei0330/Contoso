using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Data.Repositories;
using Contoso.Entities;

namespace Contoso.Services
{
    public class StudentService : IStudentService
    {
        //private StudentRepository studentRepository;
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            //studentRepository = new StudentRepository(new Data.ContosoDbContext());
            _studentRepository = studentRepository;
        }

        public void AddStudent(Student student)
        {
            _studentRepository.Add(student);
            _studentRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            _studentRepository.Delete(id);
            _studentRepository.SaveChanges();
        }

        public void Edit(Student student)
        {
            _studentRepository.Update(student);
            _studentRepository.SaveChanges();
        }

        public Student GetStudentById(int Id)
        {
           return _studentRepository.GetById(Id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _studentRepository.GetAll();
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.Update(student);
            _studentRepository.SaveChanges();
        }
    }

    public interface IStudentService
    {
        // define the methods which StudentServie will be implemented(also used by the StudentController)
        IEnumerable<Student> GetStudents();
        Student GetStudentById(int Id);
        void AddStudent(Student student);
        //void saveChanges();
        void Edit(Student student);
        void Delete(int id);
        void UpdateStudent(Student student);


    }
}
