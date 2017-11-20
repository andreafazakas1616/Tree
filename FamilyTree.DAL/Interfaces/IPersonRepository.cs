using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.DAL.Interfaces
{
    public interface IPersonRepository
    {
        List<Person> GetAllPeople();
        Person GetById(int id);
        void Update(Person modifiedPerson);
    }
}
