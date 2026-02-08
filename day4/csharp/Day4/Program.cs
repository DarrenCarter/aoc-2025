namespace Day4;

public class Solver
{
    private static readonly int[][] Dirs = [[-1, -1], [-1, 0], [-1, 1], [0, -1], [0, 1], [1, -1], [1, 0], [1, 1]];

    private static int CountNeighbors(char[][] grid, int r, int c, int rows, int cols)
    {
        int n = 0;
        foreach (var d in Dirs)
        {
            int nr = r + d[0], nc = c + d[1];
            if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && grid[nr][nc] == '@') n++;
        }
        return n;
    }

    public static (int Part1, int Part2) Solve(string input)
    {
        var lines = input.TrimEnd().Split('\n');
        int rows = lines.Length;
        int cols = rows > 0 ? lines[0].TrimEnd().Length : 0;

        var grid = new char[rows][];
        for (int i = 0; i < rows; i++)
            grid[i] = lines[i].TrimEnd().ToCharArray();

        // Part 1: count rolls with fewer than 4 neighbors
        int part1 = 0;
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                if (grid[r][c] == '@' && CountNeighbors(grid, r, c, rows, cols) < 4)
                    part1++;

        // Part 2: iteratively remove accessible rolls
        int part2 = 0;
        while (true)
        {
            var toRemove = new List<(int r, int c)>();
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    if (grid[r][c] == '@' && CountNeighbors(grid, r, c, rows, cols) < 4)
                        toRemove.Add((r, c));

            if (toRemove.Count == 0) break;
            foreach (var (r, c) in toRemove) grid[r][c] = '.';
            part2 += toRemove.Count;
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
