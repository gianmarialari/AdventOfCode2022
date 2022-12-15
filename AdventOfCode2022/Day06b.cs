static public partial class AdventOfCode2022
{
    public static string Day06b(string fileName)
    {
        using StreamReader input = new(fileName);
        string data=input.ReadLine()!;
        for (int i = 0; i < data.Length - 14; i++)
            if (data.Substring(i, 14).Distinct().Count() == 14)
                return (i + 14).ToString();
        return "";
    }
}