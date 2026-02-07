namespace Day3;

public class Solver
{
    public static (int Part1, int Part2) Solve(string input)
    {
        var lines = input.Trim().Split('\n', StringSplitOptions.RemoveEmptyEntries);

        int part1 = 0;
        int part2 = 0;

        foreach (var rawLine in lines)
        {
            var line = rawLine.Trim();
            if (line.Length == 0) continue;

            // Part 1: pick 2 batteries (i < j) to maximize 10*digit[i] + digit[j]
            int best2 = 0;
            for (int i = 0; i < line.Length; i++)
            {
                int d1 = line[i] - '0';
                for (int j = i + 1; j < line.Length; j++)
                {
                    int d2 = line[j] - '0';
                    int v = d1 * 10 + d2;
                    if (v > best2) best2 = v;
                }
            }
            part1 += best2;

            // Part 2: pick 3 batteries (i < j < k)
            int best3 = 0;
            for (int i = 0; i < line.Length; i++)
            {
                int d1 = line[i] - '0';
                for (int j = i + 1; j < line.Length; j++)
                {
                    int d2 = line[j] - '0';
                    for (int k = j + 1; k < line.Length; k++)
                    {
                        int d3 = line[k] - '0';
                        int v = d1 * 100 + d2 * 10 + d3;
                        if (v > best3) best3 = v;
                    }
                }
            }
            part2 += best3;
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
