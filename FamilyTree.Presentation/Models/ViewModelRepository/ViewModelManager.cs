using FamilyTree.BLL.Managers;
using FamilyTree.BLL.Models;
using FamilyTree.Presentation.Models.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyTree.Presentation.Models.ViewModelRepository
{
    public class ViewModelManager
    {
        private readonly DALModelRetriever _dalModelRetriever;
        private readonly FamilyManager _familyManager;
        public ViewModelManager(FamilyManager familyManager, DALModelRetriever dalModelRetriever)
        {
            _familyManager = familyManager;
            _dalModelRetriever = dalModelRetriever;
        }

        public List<PersonViewModel> GetAllPeople()
        {
            List<PersonModel> peopleModelList = _dalModelRetriever.GetAllPeople();
            List<PersonViewModel> peopleViewModelList = PersonMapper.ConvertToPersonViewModelList(peopleModelList);
            return peopleViewModelList;
        }
    }
}