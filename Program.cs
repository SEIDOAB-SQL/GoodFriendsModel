namespace GoodFriendsModel;
class Program
{
    const int nrItemsSeed = 50;
    
    static void Main(string[] args)
    {
        var _modelList = SeedModel(nrItemsSeed);
        WriteModel(_modelList);
    }

    #region Replaced by new model methods
    private static void WriteModel(List<csFriend> _modelList)
    {
        /*
        foreach (var friend in _modelList)
        {
            Console.WriteLine(friend);
        }
        */

        Console.WriteLine($"NrOfFriends: {_modelList.Count()}");
        Console.WriteLine($"NrOfFriends without any pets: {_modelList.Count(f => f.Pets == null)}");
        Console.WriteLine($"NrOfFriends without an adress: {_modelList.Count(f => f.Adress == null)}");
        
        Console.WriteLine($"First Friend: {_modelList.First()}");
        Console.WriteLine($"Last Friend: {_modelList.Last()}");
    }

    private static List<csFriend> SeedModel(int nrItems)
    {
        var _seeder = new csSeedGenerator();
        
        //Create a list of friends, adresses and pets
        var _goodfriends = _seeder.ItemsToList<csFriend>(nrItems);
        var _adresses = _seeder.ItemsToList<csAdress>(nrItems);

        //Assign adress and pet to friends
        for (int i = 0; i < nrItems; i++)
        {
            //assign an address randomly
            _goodfriends[i].Adress = (_seeder.Bool) ? _seeder.FromList(_adresses) :null;

            //Create between 0 and 3 pets
            var _pets = new List<csPet>();
            for (int c = 0; c < _seeder.Next(0,4); c++)
            {
                _pets.Add(new csPet().Seed(_seeder)); 
            }
            _goodfriends[i].Pets = (_pets.Count > 0) ? _pets : null;
        }
        return _goodfriends;
    }
    #endregion
}

