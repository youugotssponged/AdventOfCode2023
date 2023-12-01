using System.Text.RegularExpressions;

namespace AdventOfCode2023.answers;

public class Question1 : IAnswer
{
    private void Part1()
    {
        List<string> lines = Util.LoadQuestionFile(Util.QuestionFileNames[0]!);
        
        int total = 0;
        foreach (string line in lines)
        {
            char[] lineNums = line.Where(char.IsNumber).ToArray();
            char[] firstAndLast = { lineNums[0], lineNums[^1] };
            
            string lineNumStr = new string(firstAndLast);
            int lineNum = Convert.ToInt32(lineNumStr);
            
            total += lineNum;
        }
        
        Console.WriteLine("Part 1: total is " + total);
    }

    private void Part2()
    {
        List<string> lines = Util.LoadQuestionFile(Util.QuestionFileNames[0]!);
        List<string> vals = new List<string>();
        string regex = @"(\d|one|two|three|four|five|six|seven|eight|nine)";
        
        Dictionary<string, string> wordToIntCharLookup = new Dictionary<string, string>
        {
            ["one"]     = "1",
            ["two"]     = "2",
            ["three"]   = "3",
            ["four"]    = "4",
            ["five"]    = "5",
            ["six"]     = "6",
            ["seven"]   = "7",
            ["eight"]   = "8",
            ["nine"]    = "9"
        };
        
        foreach (string line in lines)
        {
            string firstNumber = Regex.Match(line, regex).ToString();
            if (firstNumber.Length > 1)
                firstNumber = wordToIntCharLookup[firstNumber];
            
            string lastNumber = Regex.Match(line, regex, RegexOptions.RightToLeft).ToString();
            if (lastNumber.Length > 1)
                lastNumber = wordToIntCharLookup[lastNumber];

            vals.Add(firstNumber + lastNumber);
        }

        int total = vals.Sum(Convert.ToInt32); 
        Console.WriteLine("Part 2: total is " + total);
    }
    
    public void Run()
    {
        Console.WriteLine("Running Question 1...");
        Part1();
        Part2();
        Console.WriteLine();
    }
}