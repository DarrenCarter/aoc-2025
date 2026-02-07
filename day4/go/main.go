package main

import (
	"fmt"
	"os"
	"strings"
)

func Solve(input string) (int, int) {
	input = strings.TrimSpace(input)
	lines := strings.Split(input, "\n")

	rows := len(lines)
	cols := 0
	if rows > 0 {
		cols = len(lines[0])
	}

	isRoll := func(r, c int) bool {
		if r < 0 || r >= rows || c < 0 || c >= cols {
			return false
		}
		return lines[r][c] == '@'
	}

	part1 := 0
	part2 := 0

	dirs := [][2]int{{-1, -1}, {-1, 0}, {-1, 1}, {0, -1}, {0, 1}, {1, -1}, {1, 0}, {1, 1}}

	for r := 0; r < rows; r++ {
		for c := 0; c < cols; c++ {
			if lines[r][c] != '@' {
				continue
			}
			neighbors := 0
			for _, d := range dirs {
				if isRoll(r+d[0], c+d[1]) {
					neighbors++
				}
			}
			if neighbors < 4 {
				part1++
			}
		}
	}

	return part1, part2
}

func main() {
	if len(os.Args) < 2 {
		fmt.Fprintf(os.Stderr, "Usage: %s <input-file>\n", os.Args[0])
		os.Exit(1)
	}

	data, err := os.ReadFile(os.Args[1])
	if err != nil {
		fmt.Fprintf(os.Stderr, "Error reading file: %v\n", err)
		os.Exit(1)
	}

	part1, part2 := Solve(string(data))
	fmt.Println("Part 1:", part1)
	fmt.Println("Part 2:", part2)
}
