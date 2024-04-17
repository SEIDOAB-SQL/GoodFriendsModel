using System;
using System.ComponentModel.DataAnnotations;

namespace GoodFriendsModel
{
	public class csAdress : ISeed<csAdress>
	{        
        public string StreetAdress { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public override string ToString() => $"{StreetAdress}, {ZipCode} {City}, {Country}";

        #region Random Seeding
        public bool Seeded { get; set; } = false;

        public csAdress Seed(csSeedGenerator _seeder)
        {
            var country = _seeder.Country;
            return new csAdress
            {
                StreetAdress = _seeder.StreetAddress(country),
                ZipCode = _seeder.ZipCode,
                City = _seeder.City(country),
                Country = country,
                Seeded = true
            };
        }
        #endregion
    }
}

