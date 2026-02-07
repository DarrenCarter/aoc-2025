namespace Day4;

public class Solver
{
    public static (int Part1, int Part2) Solve(string input)
    {
        var lines = input.TrimEnd().Split('\n');
        int rows = lines.Length;
        int cols = rows > 0 ? lines[0].TrimEnd().Length : 0;

        bool IsRoll(int r, int c)
        {
            if (r < 0 || r >= rows || c < 0 || c >= cols) return false;
            return lines[r][c] == '@';
        }

        int[][] dirs = [[- 1, -1], [-1, 0], [-1, 1], [0, -1], [0, 1], [1, -1], [1, 0], [1, 1]];

        int part1 = 0;
        int part2 = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (lines[r][c] != '@') continue;
                int neighbors = 0;
                foreach (var d in dirs)
                {
                    if (IsRoll(r + d[0], c + d[1])) neighbors++;
                }
                if (neighbors < 4) part1++;
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
            Console.Error.WriteLine("Usage: Day4 <input-file>");
            Environment.Exit(1);
        }

        var input = File.ReadAllText(args[0]);
        var (part1, part2) = Solver.Solve(input);
        Console.WriteLine($"Part 1: {part1}");
        Console.WriteLine($"Part 2: {part2}");
    }
}
