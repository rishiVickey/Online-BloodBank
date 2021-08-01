using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Models.Model
{
   public class BloodDonar
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public int Age { get; set; }
        //rather than age dob should be taken

        [Required]
        public int GenderId {get; set; }

        [ForeignKey("GenderId")]
        public Gender Gender { get; set; }


        public string City { get; set; }

        public string State { get; set; }

        [Required]
        public string PinCode { get; set; }

        [Required]
        public int BloodTypeId { get; set; }

        [ForeignKey("BloodTypeId")]
        public BloodType BloodType { get; set; }

        public string LastDonated { get; set; }

    }
}
