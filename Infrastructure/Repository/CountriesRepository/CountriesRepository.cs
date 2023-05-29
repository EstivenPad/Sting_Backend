using Core.Data.Models;
using Infrastructure.Data.Context;
using Infrastructure.Interfaces.BaseRepository;
using Infrastructure.Repository.BaseRepository;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repository.CountriesRepository
{
    public class CountriesRepository : BaseRepository<Country>
    {
        private new readonly DatabaseContext _context;
        private readonly BaseRepository<Country> _repository;

        public CountriesRepository(DatabaseContext context) : base(context)
        {
            _context = context;
            _repository = new BaseRepository<Country>(context);
        }

        public async Task<bool> CreateCountry(Country country)
        {
            try
            {
                await _context.Country.AddAsync(country);
                var isSaved = _context.SaveChanges() > 0;

                if (!isSaved)
                    throw new Exception("Country couldn't be saved");

                return isSaved;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteCountry(int id)
        {
            try
            {
                return await _repository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Country>> GetCountries()
        {
            try
            {
                return await _repository.GetAll();
            }catch(Exception)
            {
                throw;
            }
        }

        public async Task<Country> GetCountryById(int id)
        {
            try
            {
                return await _repository.GetById(id);
            }catch(Exception)
            {
                throw;
            }
        }

        public async Task<Country> UpdateCountry(Country country)
        {
            try
            {
                return await _repository.Update(country, country.Id);
            }catch(Exception)
            {
                throw;
            }
        }

    }
}
