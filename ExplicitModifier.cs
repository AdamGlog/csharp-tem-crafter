namespace FirstFiddle;

public abstract class ExplicitModifier(int modifierId, string modifierText, List<float> values, List<string> tags)
                      : Modifier(modifierId, modifierText, values, tags)
{
    // public int ModifierId { get; set; }
    // public string ModifierText { get; set; }
    // public List<float> Values { get; set; }
    // public List<string> Tags { get; set; }
}
