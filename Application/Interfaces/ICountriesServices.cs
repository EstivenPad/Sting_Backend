using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICountriesServices
    {
        Task<List<Country>> Get();
        Task<Country> GetById(int id);
        Task<bool> Create(Country country);
        Task<Country> Update(Country country);
        Task<bool> DeleteById(int id);
    }
}
