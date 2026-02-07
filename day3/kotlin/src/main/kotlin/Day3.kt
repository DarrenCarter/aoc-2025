import java.io.File

fun maxJoltage(line: String, pick: Int): Long {
    val actualPick = minOf(pick, line.length)
    val result = mutableListOf<Char>()
    var start = 0
    for (i in 0 until actualPick) {
        val end = line.length - (actualPick - i - 1)
        var bestIdx = start
        for (j in start + 1 until end) {
            if (line[j] > line[bestIdx]) bestIdx = j
        }
        result.add(line[bestIdx])
        start = bestIdx + 1
    }
    var value = 0L
    for (ch in result) {
        value = value * 10 + (ch - '0')
    }
    return value
}

fun solve(input: String): Pair<Long, Long> {
    val lines = input.trim().split("\n").map { it.trim() }.filter { it.isNotEmpty() }

    var part1 = 0L
    var part2 = 0L

    for (line in lines) {
        part1 += maxJoltage(line, 2)
        part2 += maxJoltage(line, 12)
    }

    return Pair(part1, part2)
}

fun main(args: Array<String>) {
    if (args.isEmpty()) {
        System.err.println("Usage: day3 <input-file>")
        System.exit(1)
    }

    val input = File(args[0]).readText()
    val (part1, part2) = solve(input)
    println("Part 1: $part1")
    println("Part 2: $part2")
}
