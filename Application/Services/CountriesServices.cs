using Application.Data.Helpers;
using Application.Interfaces;
using Core.Data.Models;
using Infrastructure.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CountriesServices : ICountriesServices
    {
        private readonly ICountryRepository _countryRepository;

        public CountriesServices(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
        }

        public async Task<bool> Create(Country country)
        {
            try
            {
                Helpers.VerifyNameField(country.CountryName); 
                                
                return await _countryRepository.Create(country);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteById(int id)
        {
            try
            {
                VerifyCountryInsideDatabase(id);
             
                return await _countryRepository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Country>> Get()
        {
            try
            {
                return await _countryRepository.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Country> GetById(int id)
        {
            try
            {
                return await _countryRepository.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Country> Update(Country country)
        {
            try
            {
                VerifyCountryInsideDatabase(country.Id);

                return await _countryRepository.Update(country);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void VerifyCountryInsideDatabase(int id)
        {
            var countryDB = await _countryRepository.GetById(id) ?? throw new ArgumentNullException($"There is not country with this id number: ${id}"); ;
        }
        
    }
}
