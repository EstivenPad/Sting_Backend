using Core.Data.Models;
using Infrastructure.Interfaces.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
    }
}
