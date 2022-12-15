static public partial class AdventOfCode2022
{
    public static string Day06a(string fileName)
    {
        using StreamReader input = new(fileName);
        string data=input.ReadLine()!;
        for (int i = 0; i < data.Length - 4; i++)
            if (data.Substring(i, 4).Distinct().Count() == 4)
                return (i + 4).ToString();
        return "";
    }
}