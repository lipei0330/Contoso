using Contoso.Data.Repositories;
using Contoso.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void CreateCourse(Course course)
        {
            _courseRepository.Add(course);
            _courseRepository.SaveChanges();
        }

        public void DeteleCourse(int id)
        {
            _courseRepository.Delete(id);
            _courseRepository.SaveChanges();
        }

        public Course GetCourseById(int Id)
        {
            return _courseRepository.GetById(Id);
        }

        public IEnumerable<Course> GetCourses()
        {
            return _courseRepository.GetAll();
        }

        public void UpdateCourse(Course course)
        {
            _courseRepository.Update(course);
            _courseRepository.SaveChanges();
        }
    }

    public interface ICourseService
    {
        IEnumerable<Course> GetCourses();
        Course GetCourseById(int Id);
        void CreateCourse(Course course);
        void UpdateCourse(Course course);
        void DeteleCourse(int id);
    }

    public class CourseService2 : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService2(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void CreateCourse(Course course)
        {
            _courseRepository.Add(course);
            _courseRepository.SaveChanges();
        }

        public void DeteleCourse(int id)
        {
            _courseRepository.Delete(id);
            _courseRepository.SaveChanges();
        }

        public Course GetCourseById(int Id)
        {
            return _courseRepository.GetById(Id);
        }

        public IEnumerable<Course> GetCourses()
        {
            return _courseRepository.GetAll();
        }

        public void UpdateCourse(Course course)
        {
            _courseRepository.Update(course);
            _courseRepository.SaveChanges();
        }
    }
}
