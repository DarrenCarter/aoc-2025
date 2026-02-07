import java.io.File

fun solve(input: String): Pair<Int, Int> {
    val parts = input.trim().replace(",", "\n").split("\n")

    var pos = 50
    var part1 = 0
    var part2 = 0

    for (raw in parts) {
        val part = raw.trim()
        if (part.length < 2) continue

        val dir = part[0]
        val dist = part.substring(1).toInt()

        // Part 2: count how many times dial passes through 0 during rotation
        val first = if (dir == 'L') {
            if (pos > 0) pos else 100
        } else {
            val f = (100 - pos) % 100
            if (f == 0) 100 else f
        }
        if (dist >= first) {
            part2 += (dist - first) / 100 + 1
        }

        when (dir) {
            'L' -> pos = ((pos - dist) % 100 + 100) % 100
            'R' -> pos = (pos + dist) % 100
        }

        if (pos == 0) {
            part1++
        }
    }

    return Pair(part1, part2)
}

fun main(args: Array<String>) {
    if (args.isEmpty()) {
        System.err.println("Usage: day1 <input-file>")
        System.exit(1)
    }

    val input = File(args[0]).readText()
    val (part1, part2) = solve(input)
    println("Part 1: $part1")
    println("Part 2: $part2")
}
