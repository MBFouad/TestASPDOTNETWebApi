using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_ASP_Core_Web_Api__1_.Models
{
    public class User
    {
      

        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        public string Adreess { get; set; }

        [Required]
        public string NationalId { get; set; }

    }
}
