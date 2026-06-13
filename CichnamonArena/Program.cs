using CichnamonArena;

Random rnd = new Random();

Console.WriteLine("Welcome to Cichnamon Arena!");
Console.Write("Enter your name: ");
string playerName = Console.ReadLine() ?? "Trainer";

Console.Write("Enter the opponent's name: ");
string opponentName = Console.ReadLine() ?? "Evil Trainer";

Trainer player   = new Trainer(playerName);
Trainer computer = new Trainer(opponentName);

Cichnamon oldrich = new Cichnamon("Pekelny Ondrej", 100, 5,
    new Attack("Ember",      10, "Oldrich spits a small flame."),
    new Attack("Flamethrower", 22, "A scorching stream of fire burns everything in its path!"));

Cichnamon vojtech = new Cichnamon("Vodnik Vojtech", 110, 3,
    new Attack("Splash",    9,  "Vojtech splashes cold water."),
    new Attack("Water Cannon", 20, "A powerful jet of water blasts the opponent!"));

Cichnamon tonda = new Cichnamon("Tonda travnicek", 120, 2,
    new Attack("Leaf Toss",     8,  "Tonda throws a pile of leaves in the opponent's face."),
    new Attack("Poison Cloud", 19, "A thick green mist poisons the opponent!"));

Console.WriteLine("\nChoose your Cichnamon:");
Console.WriteLine("1 - Pekelny Ondrej");
oldrich.PrintInfo();
Console.WriteLine("2 - Vodnik Vojtech");
vojtech.PrintInfo();
Console.WriteLine("3 - Tonda travnicek");
tonda.PrintInfo();

int choice = GetChoice(1, 3);
Cichnamon playerC = choice == 1 ? ondrej : choice == 2 ? vojtech : tonda;
player.AddCichnamon(playerC);
player.SelectCichnamon(0);
Console.WriteLine($"\nYou chose: {playerC.Name}");

Cichnamon villain = new Cichnamon("Darkfang", 95, 4,
    new Attack("Scratch",   10, "Darkfang slashes with sharp claws."),
    new Attack("Dark Wave", 20, "A mysterious dark energy strikes the opponent!"));

computer.AddCichnamon(villain);
computer.SelectCichnamon(0);
Console.WriteLine($"Your opponent is: {villain.Name}");

Cichnamon myCich  = player.ActiveCichnamon!;
Cichnamon oppCich = computer.ActiveCichnamon!;

bool specialUsed = false;
bool healUsed    = false;
int  turn        = 1;

while (myCich.IsAlive() &&.IsAlive())
{
    Console.WriteLine($"\n--- YOUR TURN ---");
    Console.WriteLine($"  {myCich.Name}: {myCich.CurrentHealth} HP");
    Console.WriteLine($"  .Name}: .CurrentHealth} HP");
    Console.WriteLine();

    Console.WriteLine($"1 - Basic attack: {ich.BasicAttack.Name}");

    bool canSpecial = !specialUsed || turn % 2 == 0;
    Console.WriteLine(canSpecial
        ? $"2 - Special attack: {ich.SpecialAttack.Name}"
        : $"2 - Special attack: {ich.SpecialAttack.Name} (not available yet)");

    Console.WriteLine(healUsed
        ? "3 - Heal (already used)"
        : "3 - Heal (+20 HP)");

    int action = GetChoice(1, 3);

    if (action == 1)
    {
        ich.UseBasicAttack);
    }
    else if (action == 2)
    {
        if (canSpecial)
        {
            ich.UseSpecialAttack);
            specialUsed = true;
        }
        else
        {
            Console.WriteLine("Special attack not available yet! Using basic attack instead.");
            ich.UseBasicAttack);
        }
    }
    else
    {
        if (!healUsed)
        {
            ich.Heal(20);
            healUsed = true;
            Console.WriteLine($"{ich.Name} healed for 20 HP! Health: {ich.CurrentHealth}/{ich.MaxHealth}");
        }
        else
        {
            Console.WriteLine("Heal already used! Using basic attack instead.");
            ich.UseBasicAttack);
        }
    }

    if (.IsAlive()) break;

    Console.WriteLine($"\n--- OPPONENT'S TURN ---");
    if (turn % 2 == 0)
    .UseSpecialAttack(ich);
    else
    .UseBasicAttack(ich);

    turn++;
    Console.WriteLine("\nPress Enter to continue...");
    Console.ReadLine();
}

Console.WriteLine();
if (ich.IsAlive())
{
    Console.WriteLine($"YOU WIN! {ich.Name} is victorious!");
    player.LevelUp();
    Console.WriteLine($"{player.Name} reached level {player.Level}!");

    Console.WriteLine("\nChoose a reward for your Cichnamon:");
    Console.WriteLine("1 - Increase max health (+15 HP)");
    Console.WriteLine("2 - Increase attack bonus (+3)");
    int reward = GetChoice(1, 2);
    if (reward == 1)
    {
        ich.Heal(15);
        Console.WriteLine($"{ich.Name} now has {ich.CurrentHealth}/{ich.MaxHealth} HP.");
    }
    else
    {
        Console.WriteLine($"{ich.Name} has become stronger!");
    }
}
else
{
    Console.WriteLine($"YOU LOSE! .Name} wins.");
}

Console.WriteLine("\nYour Cichnamon's final status:");
ich.PrintInfo();

Console.WriteLine("\nThanks for playing!");

static int GetChoice(int min, int max)
{
    while (true)
    {
        Console.Write("Your choice: ");
        if (int.TryParse(Console.ReadLine(), out int v) && v >= min && v <= max)
            return v;
        Console.WriteLine($"Invalid input. Enter a number between {min} and {max}.");
    }
}
