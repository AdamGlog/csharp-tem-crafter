using FirstFiddle.Util;

namespace FirstFiddle.Itemization.Mods;

public class ImplicitModifier(string modifierText, List<StatRange> statsRanges, List<string> tags)
             : Modifier(modifierText, statsRanges, tags)
{
    // public int ModifierId { get; set; } = modifierId;
    // public string ModifierText { get; set; } = modifierText;
    // public List<float> Values { get; set; } = values;
    // public List<string> Tags { get; set; } = tags;

}
