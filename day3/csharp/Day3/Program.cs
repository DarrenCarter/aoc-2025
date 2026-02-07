namespace Day3;

public class Solver
{
    public static long MaxJoltage(string line, int pick)
    {
        int actualPick = Math.Min(pick, line.Length);
        var result = new List<char>(actualPick);
        int start = 0;
        for (int i = 0; i < actualPick; i++)
        {
            int end = line.Length - (actualPick - i - 1);
            int bestIdx = start;
            for (int j = start + 1; j < end; j++)
            {
                if (line[j] > line[bestIdx]) bestIdx = j;
            }
            result.Add(line[bestIdx]);
            start = bestIdx + 1;
        }
        long value = 0;
        foreach (var ch in result)
        {
            value = value * 10 + (ch - '0');
        }
        return value;
    }

    public static (long Part1, long Part2) Solve(string input)
    {
        var lines = input.Trim().Split('\n', StringSplitOptions.RemoveEmptyEntries);

        long part1 = 0;
        long part2 = 0;

        foreach (var rawLine in lines)
        {
            var line = rawLine.Trim();
            if (line.Length == 0) continue;

            part1 += MaxJoltage(line, 2);
            part2 += MaxJoltage(line, 12);
        }

        return (part1, part2);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.Error.WriteLine("Usage: Day3 <input-file>");
            Environment.Exit(1);
        }

        var input = File.ReadAllText(args[0]);
        var (part1, part2) = Solver.Solve(input);
        Console.WriteLine($"Part 1: {part1}");
        Console.WriteLine($"Part 2: {part2}");
    }
}
