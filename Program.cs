using Tp.Actions.Attack;
using Tp.Actions.Damages;
using Tp.Characters;
using Tp.Characters.Warrior;

class Program
{
    static void Main()
    {
        var steve = new Warrior("Steve");
        var thanos = new Warrior("Thanos");
        
        var teamTarget = new List<Character>{thanos};
        
        steve.Attack(teamTarget, "Heroic Strike");
        Console.WriteLine(steve.ToString());

        /*

        Console.WriteLine("Beginning Battle of Warrior!");
        steve.Attack(thanos);
        thanos.BattleCry();
        thanos.Attack(steve);

        Console.WriteLine($"\nFinales statistics: ");
        Console.WriteLine($"{steve.Name} : {steve.PvActual}/{steve.Pv} PV.");
        Console.WriteLine($"{thanos.Name} : {thanos.PvActual}/{thanos.Pv} PV.");
        */
    }
}