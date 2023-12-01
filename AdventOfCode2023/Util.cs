namespace AdventOfCode2023;

public interface IAnswer
{
    void Run();
}

public static class Util 
{
    private const string   QuestionPath      = "../../../questions/";
    public static string?[] QuestionFileNames { get; private set; }

    public static void LoadQuestionFileNames()
    {
        QuestionFileNames = Directory.GetFiles(QuestionPath)
                                     .Select(Path.GetFileName)
                                     .ToArray();
        
        if (QuestionFileNames.Length == 0)
        {
            Console.WriteLine("[AOC2023_ERROR] :: There are no question files in the questions folder.");
            return;
        }
        
        Console.WriteLine("[AOC2023_INFO] :: Questions found!");
    }

    public static List<string> LoadQuestionFile(string fileName)
    {
        string? line;
        List<string> lines = new();
        using var sr = new StreamReader(QuestionPath + fileName);

        try 
        {
            while((line = sr.ReadLine()) != null) 
            {
                lines.Add(line);
            }
        }
        catch(IOException ioex)
        {
            Console.WriteLine($"ERROR! : {ioex.Message}, FILE CORRUPT OR NON-EXISTANT");
            sr.Dispose();
            return Enumerable.Empty<string>().ToList();
        }
        catch (OutOfMemoryException omex)
        {
            Console.WriteLine($"ERROR! : {omex.Message}, FILE TOO BIG");
            sr.Dispose();
            return Enumerable.Empty<string>().ToList();
        }

        return lines;
    }

    public static void LoadAndRunAllAnswers()
    { 
        List<Type> types = AppDomain.CurrentDomain
                                    .GetAssemblies()
                                    .SelectMany(x => x.GetTypes())
                                    .Where(x => typeof(IAnswer).IsAssignableFrom(x) && x.Name != nameof(IAnswer))
                                    .OrderBy(x => x.FullName)
                                    .ToList();
        
        if (!types.Any())
        {
            Console.WriteLine("[AOC2023_ERROR] :: There are no answers found that could be executed...");
            return;
        }

        for (var typeIndex = 0; typeIndex < types.Count; typeIndex++)
        {
            var type = types[typeIndex];
            dynamic instance = Activator.CreateInstance(type) ?? new object();
            
            Console.WriteLine($"[AOC2023_INFO] :: Now Running {nameof(instance)}");
            instance.GetType()?.GetMethod("Run")?.Invoke(instance, null);
            Console.WriteLine();
        }
    }
}