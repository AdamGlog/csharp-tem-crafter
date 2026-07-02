using FirstFiddle.Itemization;
using FirstFiddle.Itemization.Mods;
using FirstFiddle.Util;
using Newtonsoft.Json;

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

        List<ImplicitModifier> implicitModList = ModLoader.DeserializeMods<ImplicitModifier>("src/modifiers/implicits.json");
        implicitModList = ModLoader.ParseMods(implicitModList, randomizer);
        List<PrefixModifier> prefixModList = ModLoader.DeserializeMods<PrefixModifier>("src/modifiers/prefixes.json");
        prefixModList = ModLoader.ParseMods(prefixModList, randomizer);
        List<SuffixModifier> suffixModList = ModLoader.DeserializeMods<SuffixModifier>("src/modifiers/suffixes.json");
        suffixModList = ModLoader.ParseMods(suffixModList, randomizer);
        List<Modifier> modList = [];

        modList.AddRange(implicitModList);
        modList.AddRange(prefixModList);
        modList.AddRange(suffixModList);

        Console.WriteLine(JsonConvert.SerializeObject(modList, Formatting.Indented));

        foreach (var mod in modList)
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
