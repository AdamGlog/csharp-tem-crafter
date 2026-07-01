namespace FirstFiddle;

public abstract class Modifier(int modifierId, string modifierText, List<StatRange> statsRanges, List<string> tags)
{
    public int ModifierId { get; set; } = modifierId;
    public string ModifierText { get; set; } = modifierText;
    public string? ParsedModifier { get; set; }
    public List<StatRange> StatsRanges { get; set; } = statsRanges;
    public List<float> StatsRolled { get; set; } = [];
    public List<string> Tags { get; set; } = tags;

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
