import java.io.File

fun solve(input: String): Pair<Int, Int> {
    val lines = input.trim().split("\n").map { it.trimEnd() }
    val rows = lines.size
    val cols = if (rows > 0) lines[0].length else 0

    fun isRoll(r: Int, c: Int): Boolean {
        if (r < 0 || r >= rows || c < 0 || c >= cols) return false
        return lines[r][c] == '@'
    }

    val dirs = listOf(-1 to -1, -1 to 0, -1 to 1, 0 to -1, 0 to 1, 1 to -1, 1 to 0, 1 to 1)

    var part1 = 0
    var part2 = 0

    for (r in 0 until rows) {
        for (c in 0 until cols) {
            if (lines[r][c] != '@') continue
            val neighbors = dirs.count { (dr, dc) -> isRoll(r + dr, c + dc) }
            if (neighbors < 4) part1++
        }
    }

    return Pair(part1, part2)
}

fun main(args: Array<String>) {
    if (args.isEmpty()) {
        System.err.println("Usage: day4 <input-file>")
        System.exit(1)
    }

    val input = File(args[0]).readText()
    val (part1, part2) = solve(input)
    println("Part 1: $part1")
    println("Part 2: $part2")
}
