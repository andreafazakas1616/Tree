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
            _context.Entry(oldPerson).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public int Save(Person person)
        {
            _context.People.Add(person);
            _context.SaveChanges();
            return person.Id;
        }

    }
}
