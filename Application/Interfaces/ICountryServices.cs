using Application.Data.Dtos;
using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICountryServices
    {
        Task<List<CountryDTO>> Get();
        Task<CountryDTO> GetById(int id);
        Task<bool> Create(CountryDTO country);
        Task<CountryDTO> Update(CountryDTO country);
        Task<bool> DeleteById(int id);
    }
}
