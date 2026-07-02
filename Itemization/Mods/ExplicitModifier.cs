using FirstFiddle.Util;

namespace FirstFiddle.Itemization.Mods;

public abstract class ExplicitModifier(string modifierText, List<StatRange> statsRanges, List<string> tags)
                      : Modifier(modifierText, statsRanges, tags)
{
    // public int ModifierId { get; set; }
    // public string ModifierText { get; set; }
    // public List<float> Values { get; set; }
    // public List<string> Tags { get; set; }
}
