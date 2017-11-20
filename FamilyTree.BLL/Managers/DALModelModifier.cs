using FamilyTree.BLL.Mappers;
using FamilyTree.BLL.Models;
using FamilyTree.DAL;
using FamilyTree.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.BLL.Managers
{
    public class DALModelModifier
    {
        private readonly IPersonRepository _personRepository;
        public DALModelModifier(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public void Update(PersonModel personModel)
        {
            
            Person personEntity = PersonMapper.ConvertToPersonEntity(personModel);
            _personRepository.Update(personEntity);
        }

        public void Save(PersonModel personModel)
        {
          Person personEntity = PersonMapper.ConvertToPersonEntity(personModel);
          _personRepository.Save(personEntity);
        }
    }
}
