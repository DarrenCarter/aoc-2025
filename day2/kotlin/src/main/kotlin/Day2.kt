import java.io.File

fun isDouble(n: Long): Boolean {
    val s = n.toString()
    if (s.length % 2 != 0) return false
    val half = s.length / 2
    return s.substring(0, half) == s.substring(half)
}

fun isRepeated(n: Long): Boolean {
    val s = n.toString()
    for (d in 1..s.length / 2) {
        if (s.length % d != 0) continue
        val reps = s.length / d
        if (reps < 2) continue
        val pattern = s.substring(0, d)
        if ((1 until reps).all { s.substring(it * d, (it + 1) * d) == pattern }) {
            return true
        }
    }
    return false
}

fun solve(input: String): Pair<Long, Long> {
    val cleaned = input.trim().replace("\n", "").replace("\r", "")
    val ranges = cleaned.split(",").map { it.trim() }.filter { it.isNotEmpty() }

    var part1 = 0L
    var part2 = 0L

    for (range in ranges) {
        val dashIdx = range.indexOf('-')
        if (dashIdx < 0) continue

        val start = range.substring(0, dashIdx).trim().toLong()
        val end = range.substring(dashIdx + 1).trim().toLong()

        for (n in start..end) {
            if (isDouble(n)) part1 += n
            if (isRepeated(n)) part2 += n
        }
    }

    return Pair(part1, part2)
}

fun main(args: Array<String>) {
    if (args.isEmpty()) {
        System.err.println("Usage: day2 <input-file>")
        System.exit(1)
    }

    val input = File(args[0]).readText()
    val (part1, part2) = solve(input)
    println("Part 1: $part1")
    println("Part 2: $part2")
}
