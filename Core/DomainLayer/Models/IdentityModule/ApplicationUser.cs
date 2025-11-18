using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Users
{
    public class ApplicationUser :IdentityUser
    {
       
        public string DisplayName { get; set; } = default!;
        public string UserType { get; set; } = default!;
    }
}
