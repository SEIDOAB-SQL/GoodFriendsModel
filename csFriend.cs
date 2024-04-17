using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodFriendsModel
{
    public class csFriend : ISeed<csFriend>
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public csAdress Adress { get; set; } = null;    //null = no adress        

        public List<csPet> Pets { get; set; } = null;      //null = no pets 


        public string FullName => $"{FirstName} {LastName}";
        public override string ToString()
        {
            var sRet = FullName;

            if (Adress != null)
            {
                sRet += $". lives at {Adress}";
            }

            if (Pets != null)
            {
                sRet += $". Has pets ";
                foreach (var pet in Pets)
                {
                    sRet += $"{pet}, ";
                }
            }
            return sRet;
        }

        #region Random Seeding
        public bool Seeded { get; set; } = false;

        public csFriend Seed(csSeedGenerator _seeder)
        {
            var fn = _seeder.FirstName;
            var ln = _seeder.LastName;
            var country = _seeder.Country;

            //Create between 0 and 3 pets
            var _pets = new List<csPet>();
            for (int i = 0; i < _seeder.Next(0,4); i++)
            {
                _pets.Add(new csPet().Seed(_seeder)); 
            }

            return new csFriend
            {
                FirstName = fn,
                LastName = ln,
                Email = _seeder.Email(fn, ln),
                Adress = (_seeder.Bool) ? new csAdress().Seed(_seeder) :null,
                Pets = (_pets.Count > 0) ? _pets : null , 
                Seeded = true
            };
        }
        #endregion
    }
}

