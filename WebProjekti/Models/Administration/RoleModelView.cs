using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace WebProjekti.Models.Administration
{
    public class RoleModelView
    {
        [Required]
        public string RoleName { get; set; }
    }
}
