using Application.Data.Dtos;
using Application.Data.Helpers;
using Application.Interfaces;
using AutoMapper;
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

        private readonly IMapper _mapper;

        public CountryServices(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> Create(CountryDTO country)
        {
            try
            {
                var countryToDB = _mapper.Map<Countries>(country);

                Helpers.VerifyNameField(countryToDB.CountryName); 
                                
                return await _countryRepository.Create(countryToDB);
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

        public async Task<List<CountryDTO>> Get()
        {
            try
            {
                var data = await _countryRepository.GetAll();

                return data.Select(country => _mapper.Map<CountryDTO>(country)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CountryDTO> GetById(int id)
        {
            try
            {
                var data = await _countryRepository.GetById(id);

                return _mapper.Map<CountryDTO>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CountryDTO> Update(CountryDTO country)
        {
            try
            {
                var countryToDB = _mapper.Map<Countries>(country);

                VerifyCountryInsideDatabase(countryToDB.CountryId);

                var data = await _countryRepository.Update(countryToDB);
                return _mapper.Map<CountryDTO>(data);
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
