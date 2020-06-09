using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjekti.Models.Administration
{
    public class UserRoleModel
    {
        [Required]
        public string ID { get; set; }
        [Required]
        public string Username { get; set; }
        public bool IsSelected { get; set; }
    }
}
