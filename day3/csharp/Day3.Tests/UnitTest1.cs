namespace Day3.Tests;

public class SolverTests
{
    [Fact]
    public void Solve_ExampleInput()
    {
        var input = "987654321111111\n811111111111119\n234234234234278\n818181911112111";
        var (part1, part2) = Solver.Solve(input);
        Assert.Equal(357L, part1);
        Assert.Equal(3121910778619L, part2);
    }
}
