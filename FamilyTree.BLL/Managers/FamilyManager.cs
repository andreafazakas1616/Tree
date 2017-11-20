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
    public class FamilyManager
    {
       
        public List<PersonModel> FindParents(PersonModel root, List<PersonModel> personList)
        {
            List<PersonModel> parents = personList.Where(p => (root.DadId == p.Id) || (root.MomId == p.Id)).ToList();
            foreach (PersonModel parent in parents)
            {
                FindParents(parent, personList);
                root.Relatives.Add(parent);

                foreach (var relative in root.Relatives)
                {
                    relative.Relatives.Remove(root);
                }
                //FindChildren(parent, personList)
            }
            return parents;
        }

        public List<PersonModel> FindChildren(PersonModel root, List<PersonModel> personList)
        {
            List<PersonModel> children = personList.Where(p => (root.Id == p.DadId) || (root.Id == p.MomId)).ToList();
            foreach (PersonModel child in children)
            {

                FindChildren(child, personList);
                if (root.Relatives.Contains(child) == false)
                {
                    root.Relatives.Add(child);
                }
                root.ParentNode = child;
                //if (child.DadId != 0 || child.MomId != 0)
                //{
                //    FindParents(child, personList);
                //}

            }
            return children;
        }
      
        public void CheckIfIncompleteBranch(PersonModel node)
        {
            PersonModel unknownRelative = new PersonModel() { Name = "Unknown" };
            if (node.Relatives.Count == 1)
            {
                node.Relatives.Add(unknownRelative);

            }
            foreach (var relative in node.Relatives)
            {
                CheckIfIncompleteBranch(relative);
            }
        }
        
        public void CheckIfNoParents(PersonModel node)
        {

            if (node.Name != "Unknown")
            {
                PersonModel unknownRelative = new PersonModel() { Name = "Unknown" };
                if (node.Relatives.Count == 0)
                {
                    node.Relatives.Add(unknownRelative);
                    node.Relatives.Add(unknownRelative);
                }

                foreach (var relative in node.Relatives)
                {
                    CheckIfNoParents(relative);
                }
            }
        }

        public PersonModel GetFullFamilyTreeFromRoot(PersonModel node, List<PersonModel> personList)
        {
            while (node.ParentNode != null)
            {
                node = node.ParentNode;
            }
            node.Relatives = FindParents(node, personList);
            CheckIfIncompleteBranch(node);
            CheckIfNoParents(node);

            return node;
        }
    }
}
