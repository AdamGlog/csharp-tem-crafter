namespace FirstFiddle;

class Program
{

    private static readonly Random randomizer = new();

    static void Main(string[] args)
    {
        const string userName = "Adam";
        const string welcomeMessage = "Item Crafter & Inventory Manager";
        const string navigation = "\nMenu nagivation:\n1 - Craft\n2 - Show Inventory\n3 - Show Player Stats\nX - To terminate the program";
        const string menu = $"Hey {userName}!\n{welcomeMessage + navigation}";
        Console.WriteLine(menu + "\n");

        Inventory userInv = new(owner: "Adam", inventoryItems: ["Sword", "Bow"]);

        List<ImplicitModifier> modList = ModLoader.DeserializeMods<ImplicitModifier>("src/modifiers/implicits.json");
        modList = ModLoader.ParseMods(modList, randomizer);
        foreach (ImplicitModifier mod in modList)
        {
            Console.WriteLine(mod.ToString());
        }
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
                    // Console.WriteLine(testSuffixMod.ToString() + " " + testSuffixMod.ModifierText + " " + testSuffixMod.ParsedModifier);
                    // testSuffixMod.ParseModifier();
                    // Console.WriteLine(testSuffixMod.ToString() + " " + testSuffixMod.ModifierText + " " + testSuffixMod.ParsedModifier);
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
