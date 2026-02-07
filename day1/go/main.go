package main

import (
	"fmt"
	"os"
	"strings"
)

func Solve(input string) (int, int) {
	input = strings.TrimSpace(input)
	input = strings.ReplaceAll(input, ",", "\n")
	parts := strings.Split(input, "\n")

	pos := 50
	part1 := 0
	part2 := 0

	for _, part := range parts {
		part = strings.TrimSpace(part)
		if len(part) < 2 {
			continue
		}

		dir := part[0]
		var dist int
		fmt.Sscanf(part[1:], "%d", &dist)

		// Part 2: count how many times dial passes through 0 during rotation
		var first int
		if dir == 'L' {
			if pos > 0 {
				first = pos
			} else {
				first = 100
			}
		} else {
			first = (100 - pos) % 100
			if first == 0 {
				first = 100
			}
		}
		if dist >= first {
			part2 += (dist-first)/100 + 1
		}

		switch dir {
		case 'L':
			pos = ((pos - dist) % 100 + 100) % 100
		case 'R':
			pos = (pos + dist) % 100
		}

		if pos == 0 {
			part1++
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
