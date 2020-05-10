using EntityLayer.Personeli;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class ApplicationUser:IdentityUser
    {
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
    }
}
