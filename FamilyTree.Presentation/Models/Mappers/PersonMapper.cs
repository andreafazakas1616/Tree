using FamilyTree.BLL.Models;
using FamilyTree.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyTree.Presentation.Models.Mappers
{
    public class PersonMapper
    {
        //public static PersonViewModel ConvertToPersonViewModel(PersonModel model)
        //{
        //    PersonViewModel viewModel = new PersonViewModel();

        //    viewModel.Id = model.Id;
        //    viewModel.Name = model.Name;

        //    viewModel.Gender = model.Gender;

        //    viewModel.Age = model.Age;

        //    return viewModel;

        //}

        public static List<PersonViewModel> ConvertToPersonViewModelList(List<PersonModel> modelList)
        {
            List<PersonViewModel> viewModelList = modelList.Select(p => new PersonViewModel() { Id = p.Id, Name = p.Name }).ToList();
            return viewModelList;
        }

        public static EditViewModel ConvertToEditViewModel(PersonModel model)
        {
            EditViewModel viewModel = new EditViewModel();

            viewModel.Id = model.Id;
            viewModel.Name = model.Name;

            return viewModel;

        }

        public static PersonModel ConvertToPersonModel(CreateViewModel personViewModel)
        {
            PersonModel personModel = new PersonModel();
            personModel.Name = personViewModel.Name;
            personModel.Age = personViewModel.Age;
            personModel.Gender = personViewModel.Gender;

            return personModel;

        }

    }
}