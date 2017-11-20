using FamilyTree.BLL.Managers;
using FamilyTree.BLL.Models;
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

        public DataController(DALModelRetriever dalModelRetriever, DALModelModifier dalModelModifier)
        {
            _dalModelRetriever = dalModelRetriever;
            _dalModelModifier = dalModelModifier;
        }

        public ActionResult EditOrCreate(PersonModel person)
        {
            if (person.Name!="Unknown")
            {
                return RedirectToAction("Edit", person);
            }
            else
            {
                return View("Create");
            }
        }

        [HttpGet]
        public ActionResult Edit(PersonModel person)
        {
            //PersonModel person = _dalModelRetriever.GetPersonById(Id);
            return View(person);
        }

        [HttpPost]
        public ActionResult EditPerson(PersonModel person)
        {
            _dalModelRetriever.GetPersonById(person.Id);
            _dalModelModifier.Update(person);
            return Redirect("~/Home/Index");
        }


        public ActionResult Create()
        {
            return View();        
        }
    }
}
