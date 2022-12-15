static public partial class AdventOfCode2022
{
    public static string Day05a(string fileName)
    {
        using StreamReader input = new(fileName);
        List<char>[] Stack = new List<char>[10] { new(), new(), new(), new(), new(), new(), new(), new(), new(), new() };
        ReadAndProcessStackStructure();
        ReadAndProcessRearrangement();
        return CratesOnTop();

        void ReadAndProcessStackStructure()
        {
            int column = -1;
            while (true)
            {
                column++;
                char c = (char)input.Read();
                if (c == Environment.NewLine[0])
                {
                    input.ReadLine();
                    column = -1;
                    continue;
                }
                if (Char.IsDigit(c)) break;
                if (Char.IsAsciiLetter(c)) Stack[(column - 1) / 4].Insert(0, c);
            }
            input.ReadLine();
            input.ReadLine();
        }

        void ReadAndProcessRearrangement()
        {
            while (true)
            {
                string[] line = input.ReadLine()!.Split(' ');
                int numberOfCratesToMove = int.Parse(line[1]);
                int fromColumn = int.Parse(line[3]);
                int toColumn = int.Parse(line[5]);
                for (int i = 0; i < numberOfCratesToMove; i++)
                    MoveOneCrate(fromColumn - 1, toColumn - 1);
                if (input.EndOfStream) break;
            }
            void MoveOneCrate(int fromColumn, int toColumn)
            {
                char c = Stack[fromColumn].Last();
                int fromTopIndex = Stack[fromColumn].Count - 1;
                Stack[fromColumn].RemoveAt(fromTopIndex);
                Stack[toColumn].Add(c);
            }
        }
        string CratesOnTop()
        {
            string s = "";
            for (int i = 0; i < Stack.Length; i++)
                s += Stack[i].Any() ? Stack[i].Last() : "";
            return s;
        }
    }

}