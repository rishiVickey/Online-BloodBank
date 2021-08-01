using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Models.Model
{
  public  class BloodAcceptor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int GenderId { get; set; }

        [ForeignKey("GenderId")]
        public Gender Gender { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        [MaxLength(20)]
        public string City { get; set; }

        [Required]
        [MaxLength(25)]
        public string State { get; set; }

        [Required]
        [MaxLength(20)]
        public string Pincode { get; set; }

    }
}
