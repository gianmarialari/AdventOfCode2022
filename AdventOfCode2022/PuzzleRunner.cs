public class PuzzleRunner
{
    public delegate string PuzzleDelegate(string inputFileName);
    public PuzzleRunner(PuzzleDelegate RunPuzzle)
    {
        string codeName = RunPuzzle.Method.Name;
        string dayNumber = RunPuzzle.Method.Name[3..5];
        char variant = RunPuzzle.Method.Name[5];
        PrintPuzzleInfo();

        if (RunExampleWrong()) return;

        if (RunInputWrong()) return;
        Console.WriteLine("Ok!");

        void PrintPuzzleInfo()
        {
            Console.Write($"Puzzle number: {dayNumber}; ");
            Console.Write($"Puzzle variant: {variant}; ");
            Console.Write($"Puzzle program: {codeName}; ");
        }
        bool RunExampleWrong()
        {
            var result = RunPuzzle(GetExampleFileName(dayNumber));
            var expectedExampleResult = GetExampleResult(dayNumber, variant);
            if (expectedExampleResult == null)
            {
                Console.WriteLine();
                Console.WriteLine("Missing EXAMPLE solution file");
                return true;
            }
            if (!string.Equals(result, expectedExampleResult))
            {
                Console.WriteLine();
                Console.WriteLine("Wrong result for EXAMPLE input");
                Console.WriteLine($"Expected result: {expectedExampleResult}");
                Console.WriteLine($"Actual   result: {result}");
                return true;
            }
            return false;
        }
        bool RunInputWrong()
        {
            var result = RunPuzzle(GetInputFileName(dayNumber));
            var expectedInputResult = GetInputResult(dayNumber, variant);
            if (expectedInputResult == null)
            {
                Console.WriteLine($"Found: {result}");
                return true;
            }
            if (!string.Equals(result, expectedInputResult))
            {
                Console.WriteLine();
                Console.WriteLine("Wrong result for INPUT file");
                Console.WriteLine($"Expected result: {expectedInputResult}");
                Console.WriteLine($"Actual   result: {result}");
                return true;
            }
            return false;
        }
    }

    string GetExampleFileName(string dayNumber) => dayNumber + "ex.txt";
    string GetExampleResultFileName(string dayNumber, char variant) => dayNumber + variant + "-ex-sol.txt";
    string GetInputResultFileName(string dayNumber, char variant) => dayNumber + variant + "-in-sol.txt";
    string? GetExampleResult(string dayNumber, char variant)
    {
        string fileName = GetExampleResultFileName(dayNumber, variant);
        return File.Exists(fileName) ? File.ReadLines(fileName).First() : null;
    }
    string GetInputFileName(string dayNumber) => dayNumber + "in.txt ";
    string? GetInputResult(string dayNumber, char variant)
    {
        string fileName = GetInputResultFileName(dayNumber, variant);
        return File.Exists(fileName) ? File.ReadLines(fileName).First() : null;
    }
}