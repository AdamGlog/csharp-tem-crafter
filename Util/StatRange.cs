namespace FirstFiddle.Util;

public class StatRange
{
    public float Min { get; set; }
    public float Max { get; set; }
    public bool IsInt { get; set; }

    // Pick a random value between the Min and Max if same return Min
    public float Roll(Random rand)
    {
        float randomizedValue = (float)(rand.NextDouble() * (Max - Min) + Min);
        if (IsInt) return (int)randomizedValue;
        return MathF.Round(randomizedValue, 2);
    }
}
