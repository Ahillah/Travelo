using DomainLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.IdentityModule
{
    public class Tourist:ApplicationUser
    {
    


        public string IDNumber { get; set; }=default!;

       
    }
}
