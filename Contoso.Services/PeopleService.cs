using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Data.Repositories;
using Contoso.Entities;

namespace Contoso.Services
{
    public class PeopleService: IPeopleService
    {
        private PeopleRepository peopleRepository;
        public PeopleService()
        {
            peopleRepository = new PeopleRepository(new Data.ContosoDbContext());
        }

        public void AddPeople(People ppl)
        {
            peopleRepository.Add(ppl);
            peopleRepository.SaveChanges();
        }

        public void DeletePeople(int id)
        {
            peopleRepository.Delete(id);
            peopleRepository.SaveChanges();
        }

        public void EditPeople(People ppl)
        {
            peopleRepository.Update(ppl);
            peopleRepository.SaveChanges();
        }

        public IEnumerable<People> GetAllPeople()
        {
            return peopleRepository.GetAll();
        }

        public People GetPeopleById(int Id)
        {
            return peopleRepository.GetById(Id);
        }

        
    }

    //we can add new functions except using functions in BaseRepository
    public interface IPeopleService
    {
        IEnumerable<People> GetAllPeople();
        People GetPeopleById(int Id);
        void AddPeople(People ppl);
        void EditPeople(People ppl);
       // void SaveChanges();
        void DeletePeople(int id);
    }
}
