using System.Globalization;
using System.Text.RegularExpressions;

public static class TitleTextFormatter
{
    public static string ToTitleCase(this string text, bool insertSpaceBetweenCases = true)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }

        var source = insertSpaceBetweenCases ? text.InsertSpaceBetweenCases() : text;

        return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(source);
    }

    public static string InsertSpaceBetweenCases(this string text)
    {
        return string.IsNullOrEmpty(text) ? text : Regex.Replace(text, @"(?<=[a-z0-9])(?=[A-Z])|(?<=[A-Z])(?=[A-Z][a-z])", " ");
    }
}