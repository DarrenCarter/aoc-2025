import kotlin.test.Test
import kotlin.test.assertEquals

class Day3Test {
    @Test
    fun testSolveExample() {
        val input = this::class.java.getResource("/example.txt")!!.readText()
        val (part1, part2) = solve(input)
        assertEquals(357L, part1, "Part 1")
        assertEquals(3121910778619L, part2, "Part 2")
    }
}
