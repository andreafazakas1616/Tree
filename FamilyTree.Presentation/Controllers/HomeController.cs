using FamilyTree.BLL;
using FamilyTree.BLL.Managers;
using FamilyTree.BLL.Models;
using FamilyTree.DAL;
using FamilyTree.DAL.Interfaces;
using FamilyTree.DAL.Repositories;
using FamilyTree.Presentation.Models;
using FamilyTree.Presentation.Models.Mappers;
using FamilyTree.Presentation.Models.ViewModelRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyTree.Presentation.Controllers
{
    public class HomeController : Controller
    {
        //PersonRepository repo;

        //public HomeController()
        //{
        //    repo = new PersonRepository();
        //}

        private readonly FamilyManager _familyManager;
        private readonly ViewModelManager _viewModelManager;
        private readonly DALModelRetriever _dalModelRetriever;

        public HomeController(FamilyManager familyManager, ViewModelManager viewModelManager, DALModelRetriever dalModelRetriever)
        {
            _familyManager = familyManager;
            _viewModelManager = viewModelManager;
            _dalModelRetriever = dalModelRetriever;
        }

        public ActionResult Index()
        {
            List<PersonViewModel> people = _viewModelManager.GetAllPeople();
            return View(people);
        }

        public ActionResult ShowFamilyTree(PersonViewModel selectedNode)
        {
            return View(selectedNode);
        }

        public ActionResult FamilyTreePartialView(PersonViewModel node)
        {
            PersonModel selectedNode = _dalModelRetriever.GetPersonById(node.Id);
            List<PersonModel> peopleList = _dalModelRetriever.GetAllPeople();
            selectedNode.Relatives = _familyManager.FindChildren(selectedNode, peopleList);
            PersonModel lastDescendant = _familyManager.GetFullFamilyTreeFromRoot(selectedNode, peopleList);
            ViewData["SelectedNode"] = selectedNode.Id;
            return PartialView("_FamilyTree", lastDescendant);
        }


    }
}
