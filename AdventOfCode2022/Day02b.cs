static public partial class AdventOfCode2022
{
    //enum GameResult { win, loss, draw }
    //enum GameChoice { rock, scissors, paper }
    public static string Day02b(string fileName)
    {
        using StreamReader input = new(fileName);
        int totalScore = 0;
        while (true)
        {
            GameChoice elfChoice = DecodeChoiceABC((char)input.Read());
            input.Read();

            GameResult myResult = DecodeResultXYZ((char)input.Read());
            input.ReadLine();

            GameChoice myChoice = CalculateMyChoice(elfChoice, myResult);
            totalScore += EvalScore(myChoice, myResult);
            if (input.EndOfStream) break;
        }
        return totalScore.ToString();

        GameChoice DecodeChoiceABC(char choice) =>
            choice switch { 'A' => GameChoice.rock, 'B' => GameChoice.paper, 'C' => GameChoice.scissors, _ => throw new Exception() };
        GameResult DecodeResultXYZ(char result) =>
            result switch { 'X' => GameResult.loss, 'Y' => GameResult.draw, 'Z' => GameResult.win, _ => throw new Exception() };

        GameChoice CalculateMyChoice(GameChoice elfChoice, GameResult myResult)
        {
            return elfChoice switch
            {
                GameChoice.paper => myResult switch
                {
                    GameResult.win => GameChoice.scissors,
                    GameResult.draw => GameChoice.paper,
                    GameResult.loss => GameChoice.rock,
                    _ => throw new Exception()
                },
                GameChoice.rock => myResult switch
                {
                    GameResult.win => GameChoice.paper,
                    GameResult.draw => GameChoice.rock,
                    GameResult.loss => GameChoice.scissors,
                    _ => throw new Exception()
                },
                GameChoice.scissors => myResult switch
                {
                    GameResult.win => GameChoice.rock,
                    GameResult.draw => GameChoice.scissors,
                    GameResult.loss => GameChoice.paper,
                    _ => throw new Exception()
                },
                _ => throw new Exception()
            };
        }

        int EvalScore(GameChoice myGameChoice, GameResult myGameResult)
        {
            int scoreForGameResult = myGameResult switch
            {
                GameResult.loss => 0,
                GameResult.draw => 3,
                GameResult.win => 6,
                _ => throw new Exception()
            };
            int scoreForGameChoice = myGameChoice switch
            {
                GameChoice.rock => 1,
                GameChoice.paper => 2,
                GameChoice.scissors => 3,
                _ => throw new Exception()
            };
            return scoreForGameChoice + scoreForGameResult;
        }
    }
}