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
        Task<List<Countries>> Get();
        Task<Countries> GetById(int id);
        Task<bool> Create(Countries country);
        Task<Countries> Update(Countries country);
        Task<bool> DeleteById(int id);
    }
}
