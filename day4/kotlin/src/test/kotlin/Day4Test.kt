import kotlin.test.Test
import kotlin.test.assertEquals

class Day4Test {
    @Test
    fun testSolveExample() {
        val input = this::class.java.getResource("/example.txt")!!.readText()
        val (part1, part2) = solve(input)
        assertEquals(13, part1, "Part 1")
        assertEquals(43, part2, "Part 2")
    }
    @Test
    fun testSolveInput() {
        val input = this::class.java.getResource("/input.txt")!!.readText()
        val (part1, part2) = solve(input)
        assertEquals(1409, part1, "Part 1")
        assertEquals(8366, part2, "Part 2")
    }
}
