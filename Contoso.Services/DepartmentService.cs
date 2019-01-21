using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Entities;
using Contoso.Data.Repositories;

namespace Contoso.Services
{
    public class DepartmentService : IDepartmentService
    {
        // private DepartmentRepository departmentRepository;
        private readonly IDepartmentRepository _departmentRepository;
        //public DepartmentService()
        //{
        //    departmentRepository = new DepartmentRepository(new Data.ContosoDbContext());

        //}
        public DepartmentService(IDepartmentRepository departmentRepository)
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

       
    }

    public interface IDepartmentService
    {
        IEnumerable<Department> GetAllDepartments();
        Department GetDepartmentById(int Id);
        void AddDepartment(Department department);
        //void SaveChange();
        IEnumerable<Department> GetDeptByName(string name);
        void Edit(Department dept);

    }
}
