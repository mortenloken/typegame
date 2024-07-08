namespace TypeGame.Engine.Util;

public static class StringUtil
{
    public static string ListItems(string[] items) =>
        items.Length switch
        {
            0 => "ingenting",
            1 => items[0],
            _ => $"{string.Join(", ", items[..^1])} og {items[^1]}"
        };

    public static string Capitalize(this string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return s;
        }

        return char.ToUpper(s[0]) + s.Substring(1).ToLower();
    }
}
