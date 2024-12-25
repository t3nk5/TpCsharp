﻿namespace Tp.Game
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

        private List<Character> _team1 = [];
        private List<Character> _team2 = [];

        private Character SelectedCharacter { get; set; }


        private readonly List<Spell> _spellsRound = [];


        public void BeginGame()
        {
            Console.Clear();
            Console.WriteLine("Welcome to my game!");
            InitializationCharacter(2);

            Console.WriteLine("\nThe game start");

            while (!CheckWin())
            {
                Console.WriteLine("\n--- New Round ---\n");

                for (var i = 1; i <= 3; i++)
                {
                    if (_team1.Any(c => c.IsAlive))
                        ChooseAttack(NamePlayer1, _team1);
                }

                for (var i = 1; i <= 3; i++)
                {
                    if (_team2.Any(c => c.IsAlive))
                        ChooseAttack(NamePlayer2, _team2);
                }

                SortAttack();
                DisplayAttack();
                Attack();
                DecreaseCooldowns(_team1);
                DecreaseCooldowns(_team2);
            }
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

            _team1 = [];
            _team2 = [];

            var totalChoices = 6;
            for (var choice = 0; choice < totalChoices; choice++)
            {
                var isPlayer1Turn = choice % 2 == 0; // Player 1 == pair
                var currentPlayerName = isPlayer1Turn ? NamePlayer1 : NamePlayer2;
                var currentTeam = isPlayer1Turn ? _team1 : _team2;

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
            DisplayTeam(_team1);

            Console.WriteLine($"\n{NamePlayer2}'s team is ready!");
            DisplayTeam(_team2);
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
                
                if (TestIfCooldownIsGood(selectedCharacter, selectedSpell))
                {
                    SwitchTargetType(playerName, team, selectedSpell);
                }
                else
                {
                    Console.WriteLine($"The spell '{selectedSpell.Name}' of  {selectedCharacter.Name} is on cooldown! Please select another spell.");
                    ChooseAttack(playerName, team); 
                }

                
            }
        }

        private int TestTypeTarget(Spell spell)
        {
            return spell.TargetType switch
            {
                Target.EnemyTarget => 1,
                Target.TeamEnemiesTarget => 2,
                Target.Team => 3,
                Target.Partner => 4,
                Target.Yourself => 5,
                _ => 0
            };
        }

        private void SwitchTargetType(string? playerName, List<Character> team, Spell selectedSpell)
        {
            List<Character>? enemyTeam;
            switch (TestTypeTarget(selectedSpell))
            {
                case 0:
                    Console.WriteLine("No valid targets available.");
                    break;

                case 1:
                    Console.WriteLine("Which enemy?\n");
                    enemyTeam = team == _team1 ? _team2 : _team1;
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
                    _spellsRound.Add(selectedSpell);
                    break;

                case 2:
                    enemyTeam = team == _team1 ? _team2 : _team1;
                    DisplayTeam(enemyTeam);

                    var aliveEnemies = enemyTeam.Where(c => c.IsAlive).ToList();
                    if (!aliveEnemies.Any())
                    {
                        Console.WriteLine("No enemies are alive.");
                        return;
                    }

                    selectedSpell.TargetCharacters = aliveEnemies;
                    Console.WriteLine($"{playerName} has chosen to target all enemies with {selectedSpell.Name}.");
                    _spellsRound.Add(selectedSpell);
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
                    _spellsRound.Add(selectedSpell);
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
                    _spellsRound.Add(selectedSpell);
                    break;

                case 5:
                    Console.WriteLine("You use the spell on yourself.");
                    selectedSpell.TargetCharacters = [SelectedCharacter];
                    _spellsRound.Add(selectedSpell);
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
            if (_spellsRound.Count == 0)
            {
                Console.WriteLine("No spells to sort.");
                return;
            }

            var random = new Random();
            _spellsRound.Sort((spell1, spell2) =>
            {
                if (spell1.Attacker.Speed > spell2.Attacker.Speed)
                {
                    return -1; // spell1 before spell2
                }

                if (spell1.Attacker.Speed < spell2.Attacker.Speed)
                {
                    return 1; // spell2 before spell1
                }
                else
                {
                    // random when same speed
                    return random.Next(0, 2) == 0 ? -1 : 1;
                }
            });

            Console.WriteLine("Spells sorted by attacker speed:");
            foreach (var spell in _spellsRound)
            {
                Console.WriteLine($"{spell.Name} (Attacker: {spell.Attacker.Name}, Speed: {spell.Attacker.Speed})");
            }
        }

        private void DisplayAttack()
        {
            if (_spellsRound.Count == 0)
            {
                Console.WriteLine("No spells have been cast this round.");
                return;
            }

            Console.WriteLine("\nSpells cast this round:");
            var index = 1;

            foreach (var spell in _spellsRound)
            {
                Console.WriteLine($"Spell {index}:");
                Console.WriteLine($"- Name: {spell.Name}");
                Console.WriteLine($"- Cooldown: {spell.Cooldown}");
                Console.WriteLine($"- Damage: {spell.Damage}");
                Console.WriteLine($"- Mana Cost: {spell.ManaUse}");
                Console.WriteLine($"- Attacker: {spell.Attacker?.Name ?? "Unknown"}");
                Console.WriteLine($"- Target Type: {spell.TargetType}");
                Console.WriteLine($"- Type of Damage: {spell.TypeDamage}");

                if (spell.TargetCharacters.Count > 0)
                {
                    Console.WriteLine("- Targets:");
                    foreach (var target in spell.TargetCharacters)
                    {
                        Console.WriteLine($"  * {target.Name} (HP: {target.PvActual}/{target.PV})");
                    }
                }
                else
                {
                    Console.WriteLine("- Targets: None");
                }

                Console.WriteLine();
                index++;
            }
        }

        private void Attack()
        {
            _spellsRound.ForEach(spell => spell.Use());
        }

        private bool TestIfCooldownIsGood(Character character, Spell selectedSpell)
        {
            return selectedSpell.ActualCooldown == 0 || selectedSpell.ActualCooldown == 1;
        }
        
        private void DecreaseCooldowns(List<Character> team)
        {
            foreach (var character in team)
            {
                foreach (var spell in character.Spells)
                {
                    if (spell.ActualCooldown > 1)
                    {
                        spell.ActualCooldown -= 1;
                        Console.WriteLine($"Cooldown for {spell.Name} decreased to {spell.ActualCooldown}.");
                    }
                }
            }
        }


        private bool CheckWin()
        {
            if (!_team1.Any(c => c.IsAlive))
            {
                Console.WriteLine($"{NamePlayer2} wins! All characters in {NamePlayer1}'s team are defeated.");
                return true;
            }

            if (!_team2.Any(c => c.IsAlive))
            {
                Console.WriteLine($"{NamePlayer1} wins! All characters in {NamePlayer2}'s team are defeated.");
                return true;
            }

            return false;
        }
    }
}