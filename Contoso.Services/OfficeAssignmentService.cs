using Contoso.Data.Repositories;
using Contoso.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Services
{
    public class OfficeAssignmentService: IOfficeAssignmentService
    {
        private readonly IOfficeAssignmentRepository _officeAssignmentRepository;
        public OfficeAssignmentService(IOfficeAssignmentRepository officeAssignmentRepository)
        {
            _officeAssignmentRepository = officeAssignmentRepository;
        }

        public OfficeAssignment GetOfficeAssignmentById(int Id)
        {
            return _officeAssignmentRepository.GetById(Id);
        }

        public IEnumerable<OfficeAssignment> GetOfficeAssignments()
        {
            return _officeAssignmentRepository.GetAll();
        }
    }

    public interface IOfficeAssignmentService
    {
        IEnumerable<OfficeAssignment> GetOfficeAssignments();
        OfficeAssignment GetOfficeAssignmentById(int Id);
    }
}
