using FamilyTree.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.DAL.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        //ArboreGenealogicEntities _context;
        //public PersonRepository()
        //{
        //    _context = new ArboreGenealogicEntities();
        //}

        private readonly ArboreGenealogicEntities _context;
        public PersonRepository(ArboreGenealogicEntities context)
        {
            _context = context;
        }

        public List<Person> GetAllPeople()
        {
            var list = _context.People.ToList();
            list[0].Name = "Andrea";
            list[0].Age = 21;
            list[0].Gender = false;
            list[0].DadId = 10;
            list[0].MomId = 9;
            return list;
        }

        public Person GetById(int id)
        {
            Person person  = _context.People.Where(p => p.Id == id).FirstOrDefault();
            return person;
        }

        public void Update(Person modifiedPerson)
        {
            Person oldPerson = GetById(modifiedPerson.Id);
            oldPerson.Name = modifiedPerson.Name;
            oldPerson.DadId = modifiedPerson.DadId;
            oldPerson.MomId = modifiedPerson.MomId;
            oldPerson.Gender = modifiedPerson.Gender;
            oldPerson.Age = modifiedPerson.Age;

            _context.Entry(oldPerson).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
