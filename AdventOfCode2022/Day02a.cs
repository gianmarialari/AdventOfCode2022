static public partial class AdventOfCode2022
{
    enum GameResult { win, loss, draw }
    enum GameChoice { rock, scissors, paper }
    public static string Day02a(string fileName)
    {
        using StreamReader input = new(fileName);
        int totalScore = 0;
        while (true)
        {
            GameChoice elfChoice = DecodeChoiceABC((char)input.Read());
            input.Read();

            GameChoice myChoice = DecodeChoiceXYZ((char)input.Read());
            input.ReadLine();

            GameResult myResult = CalculateResult(elfChoice, myChoice);

            totalScore += CalculateScore(myChoice, myResult);
            if (input.EndOfStream) break;
        }
        return totalScore.ToString();

        GameChoice DecodeChoiceABC(char choice) =>
            choice switch { 'A' => GameChoice.rock, 'B' => GameChoice.paper, 'C' => GameChoice.scissors, _ => throw new Exception() };
        GameChoice DecodeChoiceXYZ(char choice) =>
            choice switch { 'X' => GameChoice.rock, 'Y' => GameChoice.paper, 'Z' => GameChoice.scissors, _ => throw new Exception() };

        GameResult CalculateResult(GameChoice elfChoice, GameChoice myChoice)
        {
            if (elfChoice == myChoice) return GameResult.draw;
            return (elfChoice, myChoice) switch
            {
                (GameChoice.paper, GameChoice.scissors) or
                (GameChoice.rock, GameChoice.paper) or
                (GameChoice.scissors, GameChoice.rock)
                     => GameResult.win,
                _ => GameResult.loss
            };
        }
        int CalculateScore(GameChoice myGameChoice, GameResult myGameResult)
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
            return scoreForGameResult + scoreForGameChoice;
        }
    }
}