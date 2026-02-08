import java.io.File

val dirs = listOf(-1 to -1, -1 to 0, -1 to 1, 0 to -1, 0 to 1, 1 to -1, 1 to 0, 1 to 1)

fun countNeighbors(grid: Array<CharArray>, r: Int, c: Int): Int {
    val rows = grid.size
    val cols = if (rows > 0) grid[0].size else 0
    return dirs.count { (dr, dc) ->
        val nr = r + dr; val nc = c + dc
        nr in 0 until rows && nc in 0 until cols && grid[nr][nc] == '@'
    }
}

fun solve(input: String): Pair<Int, Int> {
    val lines = input.trim().split("\n").map { it.trimEnd() }
    val rows = lines.size
    val cols = if (rows > 0) lines[0].length else 0

    val grid = Array(rows) { lines[it].toCharArray() }

    // Part 1: count rolls with fewer than 4 neighbors
    var part1 = 0
    for (r in 0 until rows) {
        for (c in 0 until cols) {
            if (grid[r][c] == '@' && countNeighbors(grid, r, c) < 4) part1++
        }
    }

    // Part 2: iteratively remove accessible rolls
    var part2 = 0
    while (true) {
        val toRemove = mutableListOf<Pair<Int, Int>>()
        for (r in 0 until rows) {
            for (c in 0 until cols) {
                if (grid[r][c] == '@' && countNeighbors(grid, r, c) < 4) {
                    toRemove.add(r to c)
                }
            }
        }
        if (toRemove.isEmpty()) break
        for ((r, c) in toRemove) grid[r][c] = '.'
        part2 += toRemove.size
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
