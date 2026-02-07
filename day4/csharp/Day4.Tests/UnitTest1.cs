namespace Day4.Tests;

public class SolverTests
{
    [Fact]
    public void Solve_ExampleInput()
    {
        var input = "..@@.@@@@.\n@@@.@.@.@@\n@@@@@.@.@@\n@.@@@@..@.\n@@.@@@@.@@\n.@@@@@@@.@\n.@.@.@.@@@\n@.@@@.@@@@\n.@@@@@@@@.\n@.@.@@@.@.";
        var (part1, _) = Solver.Solve(input);
        Assert.Equal(13, part1);
    }
}
