using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Models.Model.Authentication
{
 public class AuthenticationResponse
    {
      

        public string Message { get; set; }

        public string UserName { get; set; }

        public string Token { get; set; }
    }
}
