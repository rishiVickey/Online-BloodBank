using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Models.Model
{
  public  class BloodType
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Blood { get; set; }

    }
}
