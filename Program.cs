using Tp.Actions.Attack;
using Tp.Actions.Damages;
using Tp.Characters.Warrior;

class Program
{
    static void Main()
    {
        var steve = new Warrior("Steve");
        var thanos = new Warrior("Thanos");

        
        Console.WriteLine("Beginning Battle of Warrior!");
        steve.Attack(thanos); 
        thanos.BattleCry();
        thanos.Attack(steve);
        
        Console.WriteLine($"\nFinales statistics: ");
        Console.WriteLine($"{steve.Name} : {steve.PvActual}/{steve.Pv} PV.");
        Console.WriteLine($"{thanos.Name} : {thanos.PvActual}/{thanos.Pv} PV.");
        
    }
}



