namespace FirstFiddle;

public class ImplicitModifier(int modifierId, string modifierText, List<StatRange> statsRanges, List<string> tags)
             : Modifier(modifierId, modifierText, statsRanges, tags)
{
    // public int ModifierId { get; set; } = modifierId;
    // public string ModifierText { get; set; } = modifierText;
    // public List<float> Values { get; set; } = values;
    // public List<string> Tags { get; set; } = tags;

}
