using Core.Data.Models;
using Infrastructure.Data.Context;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.BaseRepository;
using Infrastructure.Repository.BaseRepository;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repository
{
    public class CountriesRepository : BaseRepository<Country>, ICountryRepository
    {
        private new readonly DatabaseContext _context;

        public CountriesRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

    }
}
