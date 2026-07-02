using FirstFiddle.Util;

namespace FirstFiddle.Itemization.Mods;

public class ImplicitModifier(string name, int iLevel, int tier, string modifierText, List<StatRange> statsRanges, List<string> tags)
             : Modifier(name, iLevel, tier, modifierText, statsRanges, tags)
{

}
