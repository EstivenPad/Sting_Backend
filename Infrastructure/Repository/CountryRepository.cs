using Core.Data.Models;
using Infrastructure.Data.Context;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.BaseRepository;
using Infrastructure.Repository.BaseRepository;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repository
{
    public class CountryRepository : BaseRepository<Countries>, ICountryRepository
    {
        private readonly DatabaseContext _context;
        public CountryRepository(DatabaseContext context) :base(context)
        {
            _context = context;
        }

    }
}
