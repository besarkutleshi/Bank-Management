using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjekti.Models.Administration
{
    public class UserClaim
    {
        [Required]
        public string ClaimType { get; set; }
        public bool IsSelected { get; set; }
    }
}
