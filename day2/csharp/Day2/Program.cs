namespace Day2;

public class Solver
{
    public static bool IsDouble(long n)
    {
        var s = n.ToString();
        if (s.Length % 2 != 0) return false;
        var half = s.Length / 2;
        return s[..half] == s[half..];
    }

    public static bool IsRepeated(long n)
    {
        var s = n.ToString();
        for (int d = 1; d <= s.Length / 2; d++)
        {
            if (s.Length % d != 0) continue;
            int reps = s.Length / d;
            if (reps < 2) continue;
            var pattern = s[..d];
            bool match = true;
            for (int i = 1; i < reps; i++)
            {
                if (s[(i * d)..((i + 1) * d)] != pattern)
                {
                    match = false;
                    break;
                }
            }
            if (match) return true;
        }
        return false;
    }

    public static (long Part1, long Part2) Solve(string input)
    {
        var cleaned = input.Trim().Replace("\n", "").Replace("\r", "");
        var ranges = cleaned.Split(',', StringSplitOptions.RemoveEmptyEntries);

        long part1 = 0;
        long part2 = 0;

        foreach (var range in ranges)
        {
            var trimmed = range.Trim();
            var dashIdx = trimmed.IndexOf('-');
            if (dashIdx < 0) continue;

            var start = long.Parse(trimmed[..dashIdx].Trim());
            var end = long.Parse(trimmed[(dashIdx + 1)..].Trim());

            for (var n = start; n <= end; n++)
            {
                if (IsDouble(n)) part1 += n;
                if (IsRepeated(n)) part2 += n;
            }
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
            Console.Error.WriteLine("Usage: Day2 <input-file>");
            Environment.Exit(1);
        }

        var input = File.ReadAllText(args[0]);
        var (part1, part2) = Solver.Solve(input);
        Console.WriteLine($"Part 1: {part1}");
        Console.WriteLine($"Part 2: {part2}");
    }
}
