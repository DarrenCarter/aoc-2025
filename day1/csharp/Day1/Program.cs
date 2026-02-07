namespace Day1;

public class Solver
{
    public static (int Part1, int Part2) Solve(string input)
    {
        var parts = input.Trim().Replace(",", "\n").Split('\n');

        int pos = 50;
        int part1 = 0;
        int part2 = 0;

        foreach (var raw in parts)
        {
            var part = raw.Trim();
            if (part.Length < 2) continue;

            char dir = part[0];
            int dist = int.Parse(part[1..]);

            // Part 2: count how many times dial passes through 0 during rotation
            int first;
            if (dir == 'L')
            {
                first = pos > 0 ? pos : 100;
            }
            else
            {
                first = (100 - pos) % 100;
                if (first == 0) first = 100;
            }
            if (dist >= first)
            {
                part2 += (dist - first) / 100 + 1;
            }

            switch (dir)
            {
                case 'L':
                    pos = ((pos - dist) % 100 + 100) % 100;
                    break;
                case 'R':
                    pos = (pos + dist) % 100;
                    break;
            }

            if (pos == 0) part1++;
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
            Console.Error.WriteLine("Usage: Day1 <input-file>");
            Environment.Exit(1);
        }

        var input = File.ReadAllText(args[0]);
        var (part1, part2) = Solver.Solve(input);
        Console.WriteLine($"Part 1: {part1}");
        Console.WriteLine($"Part 2: {part2}");
    }
}
