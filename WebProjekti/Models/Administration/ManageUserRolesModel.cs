using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjekti.Models.Administration
{
    public class ManageUserRolesModel
    {
        public string RoleId { get; set; }  
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }

    }
}
