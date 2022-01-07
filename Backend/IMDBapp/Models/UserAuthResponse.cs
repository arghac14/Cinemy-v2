using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBapp.Models
{
    public class UserAuthResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
