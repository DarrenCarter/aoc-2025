package main

import (
	"fmt"
	"os"
	"strings"
)

func Solve(input string) (int, int) {
	input = strings.TrimSpace(input)
	lines := strings.Split(input, "\n")

	part1 := 0
	part2 := 0

	for _, line := range lines {
		line = strings.TrimSpace(line)
		if len(line) == 0 {
			continue
		}

		// Part 1: pick exactly 2 batteries (positions i < j) to maximize 10*digit[i]+digit[j]
		best2 := 0
		for i := 0; i < len(line); i++ {
			d1 := int(line[i] - '0')
			for j := i + 1; j < len(line); j++ {
				d2 := int(line[j] - '0')
				val := d1*10 + d2
				if val > best2 {
					best2 = val
				}
			}
		}
		part1 += best2

		// Part 2: pick exactly 3 batteries (positions i < j < k) to maximize 100*digit[i]+10*digit[j]+digit[k]
		best3 := 0
		for i := 0; i < len(line); i++ {
			d1 := int(line[i] - '0')
			for j := i + 1; j < len(line); j++ {
				d2 := int(line[j] - '0')
				for k := j + 1; k < len(line); k++ {
					d3 := int(line[k] - '0')
					val := d1*100 + d2*10 + d3
					if val > best3 {
						best3 = val
					}
				}
			}
		}
		part2 += best3
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
