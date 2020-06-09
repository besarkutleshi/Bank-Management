using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Departaments
{
    public partial class Departaments
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
