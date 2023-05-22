public sealed class Colors : SmartEnum<Colors, string>
{
    public static readonly Colors Red = new Colors("R", "Red");
    public static readonly Colors Green = new Colors("G", "Green");
    public static readonly Colors Blue = new Colors("B", "Blue");

    private Colors(string value, string name)
        : base(value, name)
    {
    }
}