using FirstFiddle.Util;

namespace FirstFiddle.Itemization.Mods;

public abstract class Modifier
{
    // Auto incrementing int fo ModifierId
    private static int nextId = 1;
    public int ModifierId { get; private set; }
    public string ModifierText { get; set; }
    public string? ParsedModifier { get; set; }
    public List<StatRange> StatsRanges { get; set; }
    public List<float> StatsRolled { get; set; }
    public List<string> Tags { get; set; }

    // Constructor
    protected Modifier(string modifierText, List<StatRange> statsRanges, List<string> tags)
    {
        ModifierId = nextId++;
        ModifierText = modifierText;
        StatsRanges = statsRanges ?? []; ;
        StatsRolled = [];
        Tags = tags ?? [];
    }

    public void RollStats(Random randomizer)
    {
        // if (StatsRolled == null) return;
        StatsRolled.Clear();
        foreach (var range in StatsRanges)
        {
            StatsRolled.Add(range.Roll(randomizer));
        }
    }

    // Called only once
    // ModifierText = "+{} To Lightning Damage" | "Adds {} - {} to Lightning Damage"
    // Parser job is, to replace {} with Values[i]
    public void ParseModifier(Random randomizer)
    {

        if (string.IsNullOrEmpty(ModifierText)) ModifierText = "Empty Modifier";

        try
        {
            RollStats(randomizer);
            // Convert List<float> to an object array and unpacking it
            ParsedModifier = string.Format(ModifierText, StatsRolled.Cast<object>().ToArray());
        }
        catch (FormatException)
        {
            // Values index count is different then tokens count in string
            ParsedModifier = "Error parsing modifier formatting tokens.";
        }

    }

    public override string ToString()
    {
        if (string.IsNullOrEmpty(ModifierText)) return "Empty Modifier";
        if (string.IsNullOrEmpty(ParsedModifier)) return "Not Parsed Modifier";
        return ParsedModifier;
    }
}
