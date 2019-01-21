using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Data.Repositories;
using Contoso.Entities;

namespace Contoso.Services
{
    public class PeopleVersion2Service: IPeopleService
    {
        private readonly IPeopleRepository _peopleRepository;
        public PeopleVersion2Service(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        public void AddPeople(People ppl)
        {
            _peopleRepository.Add(ppl);
            _peopleRepository.SaveChanges();
        }

        public void DeletePeople(int id)
        {
            _peopleRepository.Delete(id);
            _peopleRepository.SaveChanges();
        }

        public void EditPeople(People ppl)
        {
            _peopleRepository.Update(ppl);
            _peopleRepository.SaveChanges();
        }

        public IEnumerable<People> GetAllPeople()
        {
            return _peopleRepository.GetAll();
        }

        public People GetPeopleById(int Id)
        {
            return _peopleRepository.GetById(Id);
        }

        


    }
}
