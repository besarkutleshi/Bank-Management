using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Persons
{
    public partial class Employees
    {
        public int? PersonId { get; set; }
        public int? DepartamentId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Salary { get; set; }
        public string Institution { get; set; }
        public string Status { get; set; }

        public virtual Departaments.Departaments Departament { get; set; }
        public virtual Persons Person { get; set; }
    }
}
