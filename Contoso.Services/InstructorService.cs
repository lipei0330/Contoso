using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Data.Repositories;
using Contoso.Entities;

namespace Contoso.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        public InstructorService(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public Instructor GetInstructorById(int Id)
        {
            return _instructorRepository.GetById(Id);
        }

        public IEnumerable<Instructor> GetInstructors()
        {
            return _instructorRepository.GetAll();
        }
    }

    public interface IInstructorService
    {
        IEnumerable<Instructor> GetInstructors();
        Instructor GetInstructorById(int Id);
       

    }
}
