public static partial class AdventOfCode2022
{
    public static string Day01a(string fileName)
    {
        using StreamReader input = new(fileName);
        int maxCalories = 0;
        while (true)
        {
            int CalorieBlock = ReadCalorieBlock();
            if (CalorieBlock > maxCalories) maxCalories = CalorieBlock;
            if (input.EndOfStream) break;
        }
        return maxCalories.ToString();

        int ReadCalorieBlock()
        {
            int totCalorie = 0;
            while (true)
            {
                string? line = input.ReadLine();
                if ((line == null) || (line == "")) return totCalorie;
                totCalorie += int.Parse(line);
            }
        }
    }
}
