static public partial class AdventOfCode2022
{
    public static string Day01b(string fileName)
    {
        using StreamReader input = new(fileName);
        List<int> top3CalorieList = new();
        while (true)
        {
            AddTop3CalorieList(ReadCalorieBlock());
            if (input.EndOfStream) break;
        }
        return (top3CalorieList[0] + top3CalorieList[1] + top3CalorieList[2]).ToString();

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
        void AddTop3CalorieList(int calorie)
        {
            if (top3CalorieList.Count<int>() < 3)
            {
                top3CalorieList.Add(calorie);
                top3CalorieList.Sort();
                return;
            }
            if (calorie > top3CalorieList[0])
            {
                top3CalorieList.Add(calorie);
                top3CalorieList.Sort();
                top3CalorieList.RemoveAt(0);
            }
        }
    }
}
