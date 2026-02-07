namespace Day1.Tests;

public class SolverTests
{
    [Fact]
    public void Solve_ExampleInput()
    {
        var input = "L68, L30, R48, L5, R60, L55, L1, L99, R14, L82";
        var (part1, part2) = Solver.Solve(input);
        Assert.Equal(3, part1);
        Assert.Equal(6, part2);
    }
}
