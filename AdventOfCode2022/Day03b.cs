static public partial class AdventOfCode2022
{
    public static string Day03b(string fileName)
    {
        using StreamReader input = new(fileName);
        int totPriority = 0;
        while (true)
        {
            (string line1,string line2,string line3) = (input.ReadLine()!,input.ReadLine()!,input.ReadLine()!);
            var intersect = line1.Intersect(line2).Intersect(line3);
            totPriority += Priority(intersect.First());
            if (input.EndOfStream) return totPriority.ToString();
        }
        int Priority(int c) => (c <= 'Z') ? c - 'A' + 27 : c - 'a' + 1;
    }
}