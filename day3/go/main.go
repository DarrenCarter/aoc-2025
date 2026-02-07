package main

import (
	"fmt"
	"os"
	"strings"
)

func maxJoltage(line string, pick int) int64 {
	if pick > len(line) {
		pick = len(line)
	}
	result := make([]byte, 0, pick)
	start := 0
	for i := 0; i < pick; i++ {
		end := len(line) - (pick - i - 1)
		bestIdx := start
		for j := start + 1; j < end; j++ {
			if line[j] > line[bestIdx] {
				bestIdx = j
			}
		}
		result = append(result, line[bestIdx])
		start = bestIdx + 1
	}
	var val int64
	for _, ch := range result {
		val = val*10 + int64(ch-'0')
	}
	return val
}

func Solve(input string) (int64, int64) {
	input = strings.TrimSpace(input)
	lines := strings.Split(input, "\n")

	var part1 int64
	var part2 int64

	for _, line := range lines {
		line = strings.TrimSpace(line)
		if len(line) == 0 {
			continue
		}

		part1 += maxJoltage(line, 2)
		part2 += maxJoltage(line, 12)
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
