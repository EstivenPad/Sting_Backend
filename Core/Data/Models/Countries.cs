using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Models
{
    public class Countries
{
        [Key]
        public int CountryId { get; set; }

        [Required]
        public string CountryName { get; set; } = string.Empty;

        [Required]
        public bool Active { get; set; }
    }
}
