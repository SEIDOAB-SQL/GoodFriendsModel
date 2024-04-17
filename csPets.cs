using System;
using System.ComponentModel.DataAnnotations;

namespace GoodFriendsModel
{
    public enum enAnimal { Dog, Cat, Rabbit, Fish, Bird };
    public class csPet : ISeed<csPet>
	{
        public enAnimal AnimalKind { get; set; }
		public string Name { get; set; }

        public override string ToString() => $"{Name} the {AnimalKind}";

        #region Random Seeding
        public bool Seeded { get; set; } = false;

        public csPet Seed(csSeedGenerator _seeder)
        {
            var country = _seeder.Country;
            return new csPet
            {
                Name = _seeder.PetName,
                AnimalKind = _seeder.FromEnum<enAnimal>(),
                Seeded = true
            };
        }
        #endregion
    }
}

