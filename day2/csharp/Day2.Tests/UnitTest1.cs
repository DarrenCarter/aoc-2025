namespace Day2.Tests;

public class SolverTests
{
    [Fact]
    public void Solve_ExampleInput()
    {
        var input = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";
        var (part1, part2) = Solver.Solve(input);
        Assert.Equal(1227775554L, part1);
        Assert.Equal(4174379265L, part2);
    }
}
