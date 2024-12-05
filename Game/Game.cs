namespace Tp.Game
{
    using Character;
    using Character.Warrior;
    using Character.Wizard;
    using Character.Paladin;
    using Character.Thief;
    using Character.Priest;
    using Spell;


    public class Game
    {
        private Dictionary<string, List<Character>> PlayersTeams = new Dictionary<string, List<Character>>();

        private int NbrPlayer { get; set; } // the number of players in the game


        public void BeginGame()
        {
            Console.Clear();
            Console.WriteLine("Welcome to my game!");
            var playerCount = GetPlayerCount();
            InitializationCharacter(playerCount);

            Console.WriteLine("Would you like to start the game? (Y/N)");

            StartRound();
        }


        private int GetPlayerCount()
        {
            int playerCount;
            while (true)
            {
                Console.WriteLine("How many players would you like to play? (Between 2 and 5)" + Environment.NewLine);
                var input = Console.ReadLine();

                if (int.TryParse(input, out playerCount) && playerCount is >= 2 and <= 5)
                {
                    NbrPlayer = playerCount;
                    return playerCount;
                }

                Console.WriteLine("Invalid input. Please enter a number between 2 and 5.");
            }
        }

        private void InitializationCharacter(int playerCount)
        {
            for (var i = 1; i <= playerCount; i++)
            {
                Console.WriteLine($"Enter the name of Player {i}:");
                var playerName = Console.ReadLine();

                Console.WriteLine($"Player {playerName}, you will select 3 characters for your team.\n");

                var playerTeam = new List<Character>();


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

                        switch (classInput)
                        {
                            case "1":
                                playerCharacter = new Warrior(characterName);
                                break;
                            case "2":
                                playerCharacter = new Wizard(characterName);
                                break;
                            case "3":
                                playerCharacter = new Paladin(characterName);
                                break;
                            case "4":
                                playerCharacter = new Thief(characterName);
                                break;
                            case "5":
                                playerCharacter = new Priest(characterName);
                                break;
                            default:
                                Console.WriteLine("Invalid selection. Please choose a valid class (1-5).");
                                break;
                        }
                    }

                    playerTeam.Add(playerCharacter);
                    Console.WriteLine(
                        $"{characterName} the {playerCharacter.GetType().Name} has been added to {playerName}'s team.");
                }

                Console.WriteLine($"\n{playerName}'s team is ready!\n");
                PlayersTeams.Add(playerName, playerTeam);
            }
        }

        private void StartRound()
        {
            
            
        }
    }
}