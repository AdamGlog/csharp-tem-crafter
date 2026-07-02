using FirstFiddle.Util;

namespace FirstFiddle.Itemization.Mods;

public class SuffixModifier(string modifierText, List<StatRange> statsRanges, List<string> tags)
             : ExplicitModifier(modifierText, statsRanges, tags)
{

}
