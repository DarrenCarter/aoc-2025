import kotlin.test.Test
import kotlin.test.assertEquals

class Day1Test {
    @Test
    fun testSolveExample() {
        val input = this::class.java.getResource("/example.txt")!!.readText()
        val (part1, part2) = solve(input)
        assertEquals(3, part1, "Part 1")
        assertEquals(6, part2, "Part 2")
    }
}
