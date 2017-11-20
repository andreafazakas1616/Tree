using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyTree.Presentation.Models
{
    public class ParentViewModel
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string ChildName { get; set; }
        public int ChildId { get; set; }
    }
}
