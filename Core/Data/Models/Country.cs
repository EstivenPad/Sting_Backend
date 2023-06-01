using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Models
{
    public class Country
{
        [Key]
        public int Id { get; set; }

        [Required]
        public string CountryName { get; set; } = string.Empty;


        [Required]
        public bool Active { get; set; }
    }
}
