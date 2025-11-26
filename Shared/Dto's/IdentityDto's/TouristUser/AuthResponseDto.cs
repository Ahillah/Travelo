using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class AuthResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
        public string DisplayName { get; set; }
       
        public string Email { get; set; }       
        public string UserType { get; set; }    
        public List<string> Errors { get; set; } = new List<string>();
    }
}
