using FirstFiddle.Util;

namespace FirstFiddle.Itemization.Mods;

public class PrefixModifier(string name, int iLevel, int tier, string modifierText, List<StatRange> statsRanges, List<string> tags)
             : ExplicitModifier(name, iLevel, tier, modifierText, statsRanges, tags)
{

}
