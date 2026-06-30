
namespace FirstFiddle;

class Program
{
    static void Main(string[] args)
    {
        const string userName = "Adam";
        const string welcomeMessage = "Item Crafter & Inventory Manager";
        const string navigation = "\nMenu nagivation:\n1 - Craft\n2 - Show Inventory\n3 - Show Player Stats\nX - To terminate the program";
        const string menu = $"Hey {userName}!\n{welcomeMessage + navigation}";
        Console.WriteLine(menu + "\n");

        Inventory userInv = new(owner: "Adam", inventoryItems: ["Sword", "Bow"]);
        ImplicitModifier testMod = new(1, "+{0} to Lightning Damage per {1} Strength", [20, 5], ["lightning"]);
        SuffixModifier testSuffixMod = new(2, "+{0}% increased Charge Recovery if you have at least {1} Intelligence", [50, 100], ["Charges", "Intelligence"]);


        while (true)
        {
            ConsoleKeyInfo userResponse = Console.ReadKey(intercept: true);
            if (userResponse.KeyChar == 'x' || userResponse.KeyChar == 'X')
            {
                Console.WriteLine("Terminating program...");
                break;
            }

            switch (userResponse.KeyChar)
            {
                case '1':
                    Console.WriteLine("Craft");
                    Console.WriteLine(testMod.ToString() + " " + testMod.ModifierText + " " + testMod.ParsedModifier);
                    testMod.ParseModifier();
                    Console.WriteLine(testMod.ToString() + " " + testMod.ModifierText + " " + testMod.ParsedModifier);
                    break;
                case '2':
                    Console.WriteLine($"This is {userInv.Owner}'s Inventory:");
                    if (userInv.InventoryItems == null)
                    {
                        Console.WriteLine("Inventory is empty :(");
                        break;
                    }

                    foreach (string item in userInv.InventoryItems)
                        Console.WriteLine(item);

                    break;
                case '3':
                    Console.WriteLine("Stats");
                    break;
                default:
                    Console.WriteLine("Wrong Button Pressed!");
                    break;
            }
        }

    }

}
