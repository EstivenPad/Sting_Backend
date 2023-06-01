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
    public class CountryServices : ICountryServices 
    {
        private readonly ICountryRepository _countryRepository;

        public CountryServices(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
        }

        public async Task<bool> Create(Countries country)
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

        public async Task<List<Countries>> Get()
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

        public async Task<Countries> GetById(int id)
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

        public async Task<Countries> Update(Countries country)
        {
            try
            {
                VerifyCountryInsideDatabase(country.CountryId);

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
