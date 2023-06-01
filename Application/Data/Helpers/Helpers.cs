using Application.Data.Dtos;
using Core.Data.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.Helpers
{
    internal class Helpers
    {
        internal static void VerifyNameField(string name)
        {
            if (name.IsNullOrEmpty())
                throw new ArgumentNullException($"Must provide the ${nameof(name)}");
        }

        internal static void VerifyEmailField(string email)
        {

        }

        internal static Country Mapper(CountryDTO country)
        {
            Country newCountry = new Country();
            newCountry += country;

            return newCountry;
        }

    }
}
