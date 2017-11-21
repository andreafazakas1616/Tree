using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.BLL.Models
{
   public class PersonModel
    {
       public PersonModel()
       {
           Relatives = new List<PersonModel>();
       }

        public PersonModel ParentNode { get; set; }
        public int Id { get; set; }
        public int DadId { get; set; }
        public int MomId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public List<PersonModel> Relatives { get; set; }
        public string ParentType { get; set; }
    }
}
