using FamilyTree.BLL.Managers;
using FamilyTree.BLL.Models;
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
    public class DataController : Controller
    {
        //
        // GET: /Data/
        private readonly DALModelRetriever _dalModelRetriever;
        private readonly DALModelModifier _dalModelModifier;
        private readonly FamilyManager _familyManager;

        public DataController(DALModelRetriever dalModelRetriever, DALModelModifier dalModelModifier, FamilyManager familyManager)
        {
            _dalModelRetriever = dalModelRetriever;
            _dalModelModifier = dalModelModifier;
            _familyManager = familyManager;
        }

        //public ActionResult EditOrCreate(PersonModel person)
        //{
        //    if (person.Name!="Unknown")
        //    {
        //        return RedirectToAction("Edit", person);
        //    }
        //    else
        //    {
        //        return View("Create");
        //    }
        //}

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            //PersonModel person = _dalModelRetriever.GetPersonById(Id);
            PersonModel person = _dalModelRetriever.GetPersonById(id);
            List<PersonModel> people = _dalModelRetriever.GetAllPeople();
            int parentCount = _familyManager.FindParents(person, people).Count;
            PersonModel parent = _familyManager.FindParents(person, people)[0];
            ViewData["parentGender"] = parent.Gender;

            EditViewModel editedPerson = PersonMapper.ConvertToEditViewModel(person);
            editedPerson.ParentCount = parentCount;
            return View(editedPerson);
        }

        [HttpPost]
        public ActionResult Edit(EditViewModel editedPerson)
        {
            if (ModelState.IsValid)
            {
                PersonModel person = _dalModelRetriever.GetPersonById(editedPerson.Id);
                person.Name = editedPerson.Name;
                _dalModelModifier.Update(person);
                return Redirect("~/Home/Index");
            }
            else
            {
                return View(editedPerson);
            }
        }

        //[HttpGet]
        //public ActionResult Create(int id)
        //{
        //    PersonModel personModel = _dalModelRetriever.GetPersonById(id);
        //    CreateViewModel parent = new CreateViewModel();
        //    return View(parent);
        //}

        //[HttpPost]
        //public ActionResult Create(CreateViewModel person)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        PersonModel personModel = PersonMapper.ConvertToPersonModel(person);
        //        _dalModelModifier.Save(personModel);
        //        return RedirectToAction("~/Home/Index");
        //    }
        //    else
        //    {
        //        return View(person);
        //    }

        //}

        [HttpGet]
        public ActionResult AddParents(EditViewModel personViewModel)
        {
            PersonModel personModel = _dalModelRetriever.GetPersonById(personViewModel.Id);
            if (personModel.Relatives[0].Gender == "Female")
            {
                ParentViewModel parent = new ParentViewModel();
                parent.ChildName = personModel.Name;
                
                return RedirectToAction("AddFather", parent);

            }
            else 
            {
                ParentViewModel parent = new ParentViewModel();
                parent.ChildName = personModel.Name;
               
                return RedirectToAction("AddMother", parent);
            }
            
            
        }

        [HttpGet]
        public ActionResult AddFather(CreateViewModel parent)
        {
            ViewData["parent"] = "father";
            return PartialView("_AddParents", parent);
        }

        [HttpGet]
        public ActionResult AddMother(CreateViewModel parent)
        {
            ViewData["parent"] = "mother";
            return PartialView("_AddParents", parent);
        }
    }
}
