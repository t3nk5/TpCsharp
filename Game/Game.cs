using Tp.Spell.TargetType;

namespace Tp.Game
{
    using Character;
    using Character.Warrior;
    using Character.Wizard;
    using Character.Paladin;
    using Character.Thief;
    using Character.Priest;
    using Spell;
    using Spell.TargetType;


    public class Game
    {
        private string? NamePlayer1 { get; set; }
        private string? NamePlayer2 { get; set; }

        private List<Character> Team1 = [];
        private List<Character> Team2 = [];

        private Character SelectedCharacter { get; set; }


        public List<Spell> SpellsRound = [];


        public void BeginGame()
        {
            Console.Clear();
            Console.WriteLine("Welcome to my game!");
            InitializationCharacter(2);

            Console.WriteLine("\nThe game start");

            for (var i = 1; i <= 3; i++)
            {
                ChooseAttack(NamePlayer1, Team1);
            }


            for (var i = 1; i <= 3; i++)
            {
                ChooseAttack(NamePlayer2, Team2);
            }


            SortAttack();

            Round();
        }


        private void InitializationCharacter(int playerCount)
        {
            if (playerCount != 2)
            {
                Console.WriteLine("This game currently supports only 2 players.");
                return;
            }

            Console.WriteLine("Enter the name of Player 1:");
            NamePlayer1 = Console.ReadLine();

            Console.WriteLine("Enter the name of Player 2:");
            NamePlayer2 = Console.ReadLine();

            Console.WriteLine($"{NamePlayer1} and {NamePlayer2}, you will now take turns to select your characters.\n");

            Team1 = [];
            Team2 = [];

            var totalChoices = 6;
            for (var choice = 0; choice < totalChoices; choice++)
            {
                var isPlayer1Turn = choice % 2 == 0; // Player 1 == pair
                var currentPlayerName = isPlayer1Turn ? NamePlayer1 : NamePlayer2;
                var currentTeam = isPlayer1Turn ? Team1 : Team2;

                Console.WriteLine($"{currentPlayerName}, it's your turn to choose a character.");
                Console.WriteLine("What class do you want?");
                Console.WriteLine("1. Warrior\n2. Wizard\n3. Paladin\n4. Thief\n5. Priest");

                var classInput = Input(5);

                Character playerCharacter = classInput switch
                {
                    "1" => new Warrior(),
                    "2" => new Wizard(),
                    "3" => new Paladin(),
                    "4" => new Thief(),
                    "5" => new Priest(),
                    _ => throw new InvalidOperationException($"Unexpected input: {classInput}")
                };

                currentTeam.Add(playerCharacter);

                Console.WriteLine(
                    $"{playerCharacter.Name} the {playerCharacter.GetType().Name} has been added to {currentPlayerName}'s team.\n");
            }


            Console.WriteLine($"\n{NamePlayer1}'s team is ready!");
            DisplayTeam(Team1);

            Console.WriteLine($"\n{NamePlayer2}'s team is ready!");
            DisplayTeam(Team2);
        }


        private void ChooseAttack(string? playerName, List<Character> team)
        {
            Console.WriteLine($"{playerName}, it's your turn\nSelect your character to attack");
            var index = 1;
            foreach (var character in team)
            {
                Console.WriteLine($"{index}- {character.Name}");
                index++;
            }

            var result = Input(team.Count);
            {
                var selectedCharacter = team[int.Parse(result) - 1];
                SelectedCharacter = selectedCharacter;
                Console.WriteLine($"\n{selectedCharacter.Name} has been selected.");
                Console.WriteLine($"Select a spell for {selectedCharacter.Name}:");
                index = 1;

                foreach (var spell in selectedCharacter.Spells)
                {
                    Console.WriteLine($"{index}. {spell.Name}");
                    index++;
                }

                result = Input(selectedCharacter.Spells.Count);
                var selectedSpell = selectedCharacter.Spells[int.Parse(result) - 1];
                SwitchTargetType(playerName, team, selectedSpell);
            }
        }

        private int TestTypeTarget()
        {
            foreach (var spell in SpellsRound)
            {
                switch (spell.TargetType)
                {
                    case Target.EnemyTarget:
                        return 1;
                    case Target.TeamEnemiesTarget:
                        return 2;
                    case Target.Team:
                        return 3;
                    case Target.Partner:
                        return 4;
                    case Target.Yourself:
                        return 5;
                }
            }

            return 0;
        }

        private void SwitchTargetType(string? playerName, List<Character> team, Spell selectedSpell)
        {
            List<Character>? enemyTeam;
            switch (TestTypeTarget())
            {
                case 0:
                    Console.WriteLine("No valid targets available.");
                    break;

                case 1:
                    Console.WriteLine("Which enemy?\n");
                    enemyTeam = team == Team1 ? Team2 : Team1;
                    DisplayTeam(enemyTeam);

                    var aliveCharacters = enemyTeam.Where(c => c.IsAlive).ToList();
                    if (!aliveCharacters.Any())
                    {
                        Console.WriteLine("No enemies are alive.");
                        return;
                    }

                    var result = Input(aliveCharacters.Count);
                
                    var selectedTarget = aliveCharacters[int.Parse(result) - 1];
                    Console.WriteLine($"{playerName} has chosen to target {selectedTarget.Name}.");
                    selectedSpell.TargetCharacters = [selectedTarget];
                    SpellsRound.Add(selectedSpell);
                

                    break;

                case 2:
                    enemyTeam = team == Team1 ? Team2 : Team1;
                    DisplayTeam(enemyTeam);

                    var aliveEnemies = enemyTeam.Where(c => c.IsAlive).ToList();
                    if (!aliveEnemies.Any())
                    {
                        Console.WriteLine("No enemies are alive.");
                        return;
                    }

                    selectedSpell.TargetCharacters = aliveEnemies;
                    Console.WriteLine($"{playerName} has chosen to target all enemies with {selectedSpell.Name}.");
                    SpellsRound.Add(selectedSpell);
                    break;

                case 3:
                    Console.WriteLine("Which allies?\n");
                    var aliveAllies = team.Where(c => c.IsAlive).ToList();
                    if (!aliveAllies.Any())
                    {
                        Console.WriteLine("No allies are alive.");
                        return;
                    }

                    selectedSpell.TargetCharacters = aliveAllies;
                    Console.WriteLine($"{playerName} has chosen to target all allies with {selectedSpell.Name}.");
                    SpellsRound.Add(selectedSpell);
                    break;

                case 4:
                    Console.WriteLine("Targeting teammates\n");
                    var teammates = team.Where(c => c.IsAlive && c != SelectedCharacter).ToList();
                    if (!teammates.Any())
                    {
                        Console.WriteLine("No teammates are alive.");
                        return;
                    }

                    DisplayTeam(teammates);
                    selectedSpell.TargetCharacters = teammates;
                    Console.WriteLine($"{playerName} has chosen to target their teammates with {selectedSpell.Name}.");
                    SpellsRound.Add(selectedSpell);
                    break;

                case 5: 
                    Console.WriteLine("You use the spell on yourself.");
                    selectedSpell.TargetCharacters = [SelectedCharacter];
                    SpellsRound.Add(selectedSpell);
                    break;

                default:
                    Console.WriteLine("Invalid target type.");
                    break;
            }
        }


        private void DisplayTeam(List<Character> team)
        {
            var index = 1;
            foreach (var character in team)
            {
                Console.WriteLine($"{index}- {character.Name}");
                index++;
            }
        }

        private string Input(int numberOfPossibilities)
        {
            Console.WriteLine($"Enter a number between 1 and {numberOfPossibilities}:");

            while (true)
            {
                var result = Console.ReadLine();
                if (int.TryParse(result, out var number) && number >= 1 && number <= numberOfPossibilities)
                {
                    return result;
                }

                Console.WriteLine("Invalid input. Please try again.");
            }
        }


        private void SortAttack()
        {
            foreach (var spell in SpellsRound)
            {
                Console.WriteLine(spell.Name);
            }
        }


        private void Round()
        {
        }


        private void CheckWin()
        {
        }
    }
}