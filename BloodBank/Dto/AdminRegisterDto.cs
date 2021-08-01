using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBank.Dto
{
    public class AdminRegisterDto
    {
        
        [Required(ErrorMessage ="UserName is required")]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage ="You should enter a Role to register")]
        public string Role { get; set; }

        [Required(ErrorMessage ="Password should be strong enough")]
        public string Password { get; set; }

    }
}
