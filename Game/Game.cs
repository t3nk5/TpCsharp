namespace Tp.Game
{
    using Character;
    using Character.Warrior;
    using Character.Wizard;
    using Character.Paladin;
    using Character.Thief;
    using Character.Priest;


    public class Game
    {
        private string? NamePlayer1 { get; set; }
        private string? NamePlayer2 { get; set; }

        private List<Character> Team1 = [];
        private List<Character> Team2 = [];


        public void BeginGame()
        {
            Console.Clear();
            Console.WriteLine("Welcome to my game!");
            InitializationCharacter(2);

            Console.WriteLine("The game start");
            Round();
        }


        private void InitializationCharacter(int playerCount)
        {
            for (var i = 1; i <= playerCount; i++)
            {
                Console.WriteLine($"Enter the name of Player {i}:");
                var playerName = Console.ReadLine();

                switch (i)
                {
                    case 1:
                        NamePlayer1 = playerName;
                        break;
                    case 2:
                        NamePlayer2 = playerName;
                        break;
                }

                Console.WriteLine($"Player {playerName}, you will select 3 characters for your team.\n");

                var playerTeam = i == 1 ? Team1 : Team2;

                for (var j = 1; j <= 3; j++)
                {
                    Console.WriteLine($"Enter the name of Character {j}:");
                    var characterName = Console.ReadLine();

                    Console.WriteLine($"Select the class for {characterName}:");
                    Console.WriteLine("1. Warrior\n2. Wizard\n3. Paladin\n4. Thief\n5. Priest");

                    Character playerCharacter = null;

                    while (playerCharacter == null)
                    {
                        var classInput = Console.ReadLine();

                        playerCharacter = classInput switch
                        {
                            "1" => new Warrior(characterName),
                            "2" => new Wizard(characterName),
                            "3" => new Paladin(characterName),
                            "4" => new Thief(characterName),
                            "5" => new Priest(characterName),
                            _ => null
                        };

                        if (playerCharacter == null)
                        {
                            Console.WriteLine("Invalid selection. Please choose a valid class (1-5).");
                        }
                    }

                    playerTeam.Add(playerCharacter);
                    Console.WriteLine(
                        $"{characterName} the {playerCharacter.GetType().Name} has been added to {playerName}'s team.");
                }

                Console.WriteLine($"\n{playerName}'s team is ready!\n");
            }
        }

        private void Round()
        {
            Console.WriteLine($"{NamePlayer1} it's your turn\nSelect your character to attack");
            var index = 1; 
            foreach (var character in Team1)
            {
                Console.WriteLine($"{index}. {character.Name}");
                index++;
            }

            var result = Console.ReadLine();

            while (int.TryParse(result, out var number) && number is >= 1 and <= 3)
            { 
                Console.WriteLine("Enter another number between 1 and 3 (or any other key to exit):");
                result = Console.ReadLine();
            }
            
            switch (result)
            {
                case "1":
                    Team1[0].Choice();
                    break;
                
                case "2":
                    Team1[1].Choice();
                    break;
                
                case "3":
                    Team1[2].Choice();
                    break;
                    
            }
            


        }


        private void CheckWin()
        {
        }
    }
}