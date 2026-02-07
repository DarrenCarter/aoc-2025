import kotlin.test.Test
import kotlin.test.assertEquals

class Day2Test {
    @Test
    fun testSolveExample() {
        val input = this::class.java.getResource("/example.txt")!!.readText()
        val (part1, part2) = solve(input)
        assertEquals(1227775554L, part1, "Part 1")
        assertEquals(4174379265L, part2, "Part 2")
    }
}
