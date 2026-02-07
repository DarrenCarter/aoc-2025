import java.io.File

fun solve(input: String): Pair<Int, Int> {
    val lines = input.trim().split("\n").map { it.trim() }.filter { it.isNotEmpty() }

    var part1 = 0
    var part2 = 0

    for (line in lines) {
        // Part 1: pick 2 batteries (i < j) to maximize 10*digit[i] + digit[j]
        var best2 = 0
        for (i in line.indices) {
            val d1 = line[i] - '0'
            for (j in i + 1 until line.length) {
                val d2 = line[j] - '0'
                val v = d1 * 10 + d2
                if (v > best2) best2 = v
            }
        }
        part1 += best2

        // Part 2: pick 3 batteries (i < j < k)
        var best3 = 0
        for (i in line.indices) {
            val d1 = line[i] - '0'
            for (j in i + 1 until line.length) {
                val d2 = line[j] - '0'
                for (k in j + 1 until line.length) {
                    val d3 = line[k] - '0'
                    val v = d1 * 100 + d2 * 10 + d3
                    if (v > best3) best3 = v
                }
            }
        }
        part2 += best3
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
