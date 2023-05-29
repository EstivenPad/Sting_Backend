using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.CountriesRepository
{
    public interface IcountryRepository
    {
        Task<List<Country>> GetCountries();
        Task<Country> GetCountryById(int id);
        Task<bool> CreateCountry(Country country);
        Task<Country> UpdateStudent(Country country);
        Task<bool> DeleteCountryById(int id);
    }
}
