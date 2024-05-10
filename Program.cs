namespace GoodFriendsModel;
class Program
{
    static void Main(string[] args)
    {
        var _modelList = SeedModel();
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

    private static List<csFriend> SeedModel()
    {
        var _seeder = new csSeedGenerator();
        
        //Create a list of friends
        var _goodfriends = new List<csFriend>();
        for (int c = 0; c < 20; c++)
        {
            _goodfriends.Add(new csFriend().Seed(_seeder));
        }
        return _goodfriends;
    }
    #endregion
}

