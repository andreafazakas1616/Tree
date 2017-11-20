using FamilyTree.BLL.Models;
using FamilyTree.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.BLL.Mappers
{
    public class PersonMapper
    {
        public static PersonModel ConvertToPersonModel(Person entity)
        {
            PersonModel model = new PersonModel();
            model.Id = entity.Id;
            model.DadId = entity.DadId??0;
            model.MomId = entity.MomId??0;
            if (entity.Gender == false)
            {
                model.Gender = "Female";
            }
            else 
            {
                model.Gender = "Male";
            }

            model.Age = entity.Age??0;
            model.Name = entity.Name;

            return model;
        }

        public static Person ConvertToPersonEntity(PersonModel model)
        {
            Person entity = new Person();
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.DadId = model.DadId;
            entity.MomId = model.MomId;
            entity.Age = model.Age;

            if (model.Gender == "Female")
            {
                entity.Gender = false;
            }
            else
            {
                entity.Gender = true;
            }

            return entity;
        }

        public static List<PersonModel> ConvertToPersonModelList(List<Person> entityList)
        {
            List<PersonModel> modelList = new List<PersonModel>();
            modelList = entityList.Select(p => new PersonModel() { Id = p.Id, Name = p.Name, Age = p.Age ?? 0, DadId = p.DadId ?? 0, MomId = p.MomId ?? 0, Gender = (p.Gender==false)?"Female":"Male" }).ToList();
            return modelList;
        }
    }
}
