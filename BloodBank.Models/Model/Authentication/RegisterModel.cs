using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Models.Model.Authentication
{
  public  class RegisterModel
    {
        [Required(ErrorMessage ="User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Email is required")]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

       

        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }

    }
}
