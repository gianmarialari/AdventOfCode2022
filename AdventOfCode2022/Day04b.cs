static public partial class AdventOfCode2022
{
    public static string Day04b(string fileName)
    {
        using StreamReader input = new(fileName);
        int fullyContainCount = 0;
        while (true)
        {
            (int, int) intervalA = (ReadNumber(input), ReadNumber(input));
            (int, int) intervalB = (ReadNumber(input), ReadNumber(input));
            if (!NoOverlap(intervalA, intervalB)) fullyContainCount++;
            if (input.EndOfStream) break;
            input.ReadLine();
        }
        return fullyContainCount.ToString();

        int ReadNumber(StreamReader input)
        {
            string s = "";
            while (true)
            {
                char c = (char)input.Read();
                if (!char.IsDigit(c)) break;
                s += c;
            }
            return int.Parse(s);
        }
        bool NoOverlap((int, int) a, (int, int) b) => a.Item2 < b.Item1 || a.Item1 > b.Item2;
    }
}