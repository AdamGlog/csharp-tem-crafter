namespace FirstFiddle;

public class Item(string name, List<ImplicitModifier> implicits, List<PrefixModifier> prefixes, List<SuffixModifier> suffixes)
{
    public string Name { get; set; } = name;
    public List<ImplicitModifier> Implicits { get; set; } = implicits;
    public List<PrefixModifier> Prefixes { get; set; } = prefixes;
    public List<SuffixModifier> Suffixes { get; set; } = suffixes;
}
