﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyTree.Presentation.Models
{
    public class EditViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int ParentCount { get; set; }
    }
}