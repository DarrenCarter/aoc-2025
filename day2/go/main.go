package main

import (
	"fmt"
	"os"
	"strconv"
	"strings"
)

func isDouble(n int64) bool {
	s := strconv.FormatInt(n, 10)
	if len(s)%2 != 0 {
		return false
	}
	half := len(s) / 2
	return s[:half] == s[half:]
}

func Solve(input string) (int64, int64) {
	input = strings.TrimSpace(input)
	// Replace newlines with nothing to handle multi-line input
	input = strings.ReplaceAll(input, "\n", "")
	input = strings.ReplaceAll(input, "\r", "")

	parts := strings.Split(input, ",")

	var part1 int64
	var part2 int64

	for _, part := range parts {
		part = strings.TrimSpace(part)
		if part == "" {
			continue
		}

		dashIdx := strings.Index(part, "-")
		if dashIdx < 0 {
			continue
		}

		startStr := strings.TrimSpace(part[:dashIdx])
		endStr := strings.TrimSpace(part[dashIdx+1:])

		start, err1 := strconv.ParseInt(startStr, 10, 64)
		end, err2 := strconv.ParseInt(endStr, 10, 64)
		if err1 != nil || err2 != nil {
			continue
		}

		for n := start; n <= end; n++ {
			if isDouble(n) {
				part1 += n
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
