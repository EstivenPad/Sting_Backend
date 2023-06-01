using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.Dtos
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public static CountryDTO operator +(CountryDTO countryDTO, Countries country) 
        {
            countryDTO.Id = country.CountryId;
            countryDTO.Name = country.CountryName;
            countryDTO.IsActive = country.Active;
            return countryDTO;
        }

        public static Countries operator +(Countries country, CountryDTO countryDTO)
        {
            country.CountryId = countryDTO.Id;
            country.CountryName = countryDTO.Name;
            country.Active = countryDTO.IsActive;
            return country;
        }
    }
}
