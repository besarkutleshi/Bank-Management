using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjekti.Models.Administration
{
    public class EditUserModel
    {
        public EditUserModel()
        {
            Claims = new List<string>(); Roles = new List<string>();
        }
        public string UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required] [EmailAddress]
        public string Email { get; set; }
        public List<string> Claims { get; set; }
        public IList<string> Roles { get; set; }

    }
}
