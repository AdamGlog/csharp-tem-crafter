namespace FirstFiddle;

using Newtonsoft.Json;

public static class ModLoader
{

    public static List<T> DeserializeMods<T>(string path) where T : Modifier
    {
        string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
        if (!File.Exists(fullPath))
        {
            throw new FileNotFoundException($"Could not find file at: {fullPath}");
        }
        return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(fullPath)) ?? new List<T>();
    }

    public static List<T> ParseMods<T>(List<T> mods) where T : Modifier
    {
        if (mods == null || mods.Count == 0) return [];
        foreach (T mod in mods)
        {
            mod.ParseModifier();
        }
        return mods ?? [];
    }

}
