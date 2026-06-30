namespace FirstFiddle;

public abstract class Modifier(int modifierId, string modifierText, List<float> values, List<string> tags)
{
    public int ModifierId { get; set; } = modifierId;
    public string ModifierText { get; set; } = modifierText;
    public string? ParsedModifier { get; set; }
    public List<float> Values { get; set; } = values;
    public List<string> Tags { get; set; } = tags;

    public void ParseModifier()
    {
        // ModifierText = "+{} To Lightning Damage" | "Adds {} - {} to Lightning Damage"
        // Parser job is, to replace {} with Values[i]
        if (string.IsNullOrEmpty(ModifierText)) ModifierText = "Empty Modifier";

        try
        {
            // Convert List<float> to an object array and unpacking it
            ParsedModifier = string.Format(ModifierText, Values.Cast<object>().ToArray());
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
