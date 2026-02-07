import kotlin.test.Test
import kotlin.test.assertEquals

class Day4Test {
    @Test
    fun testSolveExample() {
        val input = this::class.java.getResource("/example.txt")!!.readText()
        val (part1, _) = solve(input)
        assertEquals(13, part1, "Part 1")
    }
}
