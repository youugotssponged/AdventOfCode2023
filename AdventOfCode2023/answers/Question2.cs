namespace AdventOfCode2023.answers;

public class Question2 : IAnswer
{
    private void Part1()
    {
        List<string> lines = Util.LoadQuestionFile(Util.QuestionFileNames[1]!);
        List<int> possibleGames = new List<int>();
        
        foreach (var game in lines)
        {
            string[] gameAndCubes = game.Split(":");
            string[] cubeSets     = gameAndCubes[1].Split(";");
            int      gameId       = Convert.ToInt32(gameAndCubes[0].Split(" ")[1]); 
            
            int setsPassed = 0;
            int setsToPass = cubeSets.Length;
            
            foreach (var set in cubeSets)
            {
                int totalRedFound = 0;
                int totalGreenFound = 0;
                int totalBlueFound = 0;
                
                string[] cubesInSet = set.Split(",");
                foreach (var cubes in cubesInSet)
                {
                    string[] identity = cubes.TrimStart().Split(" ");
                    int numberOf = Convert.ToInt32(identity[0]);
                    
                    switch (identity[1]) // red
                    {
                        case "red":
                            totalRedFound += numberOf;
                            break;
                        case "green":
                            totalGreenFound += numberOf;
                            break;
                        case "blue":
                            totalBlueFound += numberOf;
                            break;
                    }
                }

                if (totalRedFound <= 12 && totalGreenFound <= 13 && totalBlueFound <= 14) 
                    setsPassed += 1;
            }

            if (setsPassed == setsToPass)
                possibleGames.Add(gameId);
        }
        
        Console.WriteLine("Part 1: total is " + possibleGames.Sum());
    }

    

    private void Part2()
    {
        List<string> lines = Util.LoadQuestionFile(Util.QuestionFileNames[1]!);
        List<int> possibleGames = new List<int>();

        foreach (var game in lines)
        {
            string[] gameAndCubes = game.Split(":");
            string[] cubeSets     = gameAndCubes[1].Split(";");
            int      gameId       = Convert.ToInt32(gameAndCubes[0].Split(" ")[1]); 
            
            int setsPassed = 0;
            int setsToPass = cubeSets.Length;
            
            int maxRedFound = 0;
            int maxGreenFound = 0;
            int maxBlueFound = 0;
            
            foreach (var set in cubeSets)
            {
                string[] cubesInSet = set.Split(",");
                foreach (var cubes in cubesInSet)
                {
                    string[] identity = cubes.TrimStart().Split(" "); 
                    int numberOf = Convert.ToInt32(identity[0]);
                    
                    switch (identity[1])
                    {
                        case "red":
                            if (numberOf > maxRedFound)
                            {
                                maxRedFound = numberOf;
                            }
                            break;
                        case "green":
                            if (numberOf > maxGreenFound)
                            {
                                maxGreenFound = numberOf;
                            }
                            break;
                        case "blue":
                            if (numberOf > maxBlueFound)
                            {
                                maxBlueFound = numberOf;
                            }
                            break;
                    }
                }
                
            }
            
            possibleGames.Add((maxRedFound * maxGreenFound * maxBlueFound));
        }
        
        Console.WriteLine("Part 2: total is " + possibleGames.Sum());
    }
    
    public void Run()
    {
        Console.WriteLine("Running Question 2...");
        Part1();
        Part2();
        Console.WriteLine();
    }
}