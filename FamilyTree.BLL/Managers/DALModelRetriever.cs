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
    public class DALModelRetriever
    {
        private readonly IPersonRepository _personRepository;
        private readonly FamilyManager _familyManager;

        public DALModelRetriever(IPersonRepository personRepository, FamilyManager familyManager)
        {
            _personRepository = personRepository;
            _familyManager = familyManager;
        }

        public List<PersonModel> GetAllPeople()
        {
            List<Person> entityList = _personRepository.GetAllPeople();
            List<PersonModel> modelList = PersonMapper.ConvertToPersonModelList(entityList);
            return modelList;
        }

        public PersonModel GetPersonById(int id)
        {
            PersonModel person = new PersonModel();
            var entity = _personRepository.GetById(id);
            person = PersonMapper.ConvertToPersonModel(entity);
            return person;
        }

    }
}
