static public partial class AdventOfCode2022
{
    public static string Day03a_2(string fileName)
    {
        using StreamReader input = new(fileName);
        int totPriority = 0;
        while (true)
        {
            string line = input.ReadLine()!;
            int l = line.Length;
            string half1 = line[0..((l / 2))];
            string half2 = line[(l / 2)..];
            foreach (var c in half1)
            {
                if (half2.Contains(c))
                {
                    totPriority += Priority(c);
                    break;
                }
            }
            if (input.EndOfStream) return totPriority.ToString();
        }
        int Priority(int c) => (c <= 'Z') ? c - 'A' + 27 : c - 'a' + 1;
    }
}