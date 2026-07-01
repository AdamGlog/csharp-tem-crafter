namespace FirstFiddle;

public class PrefixModifier(int modifierId, string modifierText, List<StatRange> statsRanges, List<string> tags)
             : ExplicitModifier(modifierId, modifierText, statsRanges, tags)
{

}
