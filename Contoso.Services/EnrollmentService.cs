using Contoso.Data.Repositories;
using Contoso.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Services
{
    public class EnrollmentService: IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentService(IEnrollmentRepository enorllmentRepository)
        {
            _enrollmentRepository = enorllmentRepository;
        }

        public Enrollment GetEnrollmentById(int Id)
        {
            return _enrollmentRepository.GetById(Id);
        }

        public IEnumerable<Enrollment> GetEnrollments()
        {
            return _enrollmentRepository.GetAll();
        }
    }

    public interface IEnrollmentService
    {
        IEnumerable<Enrollment> GetEnrollments();
        Enrollment GetEnrollmentById(int Id);
    }
}
