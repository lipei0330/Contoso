using Contoso.Data.Repositories;
using Contoso.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contoso.Services
{
    public class DepratmentVersion2Service : IDepartmentService
    {
        
        private readonly IDepartmentRepository _departmentRepository;
        //public DepartmentService()
        //{
        //    departmentRepository = new DepartmentRepository(new Data.ContosoDbContext());

        //}
        public DepratmentVersion2Service(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;

        }

       

        public void AddDepartment(Department department)
        {
            _departmentRepository.Add(department);
        }

        public void Edit(Department dept)
        {
            _departmentRepository.Update(dept);
            _departmentRepository.SaveChanges();
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _departmentRepository.GetAll();
        }

        public Department GetDepartmentById(int Id)
        {
            return _departmentRepository.GetById(Id);
        }

        public IEnumerable<Department> GetDeptByName(string name)
        {
            return _departmentRepository.GetDeptByName(name);
        }

        //public void SaveChange()
        //{
        //    _departmentRepository.SaveChanges();
        //}
    }
}

