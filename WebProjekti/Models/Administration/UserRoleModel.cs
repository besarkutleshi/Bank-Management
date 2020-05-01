using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjekti.Models.Administration
{
    public class UserRoleModel
    {
        public string ID { get; set; }
        public string Username { get; set; }
        public bool IsSelected { get; set; }
    }
}
