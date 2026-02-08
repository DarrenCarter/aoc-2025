package main

import (
	"fmt"
	"os"
	"strings"
)

var dirs = [][2]int{{-1, -1}, {-1, 0}, {-1, 1}, {0, -1}, {0, 1}, {1, -1}, {1, 0}, {1, 1}}

func countNeighbors(grid [][]byte, r, c, rows, cols int) int {
	n := 0
	for _, d := range dirs {
		nr, nc := r+d[0], c+d[1]
		if nr >= 0 && nr < rows && nc >= 0 && nc < cols && grid[nr][nc] == '@' {
			n++
		}
	}
	return n
}

func Solve(input string) (int, int) {
	input = strings.TrimSpace(input)
	lines := strings.Split(input, "\n")

	rows := len(lines)
	cols := 0
	if rows > 0 {
		cols = len(lines[0])
	}

	grid := make([][]byte, rows)
	for i, line := range lines {
		grid[i] = []byte(line)
	}

	// Part 1: count rolls with fewer than 4 neighbors
	part1 := 0
	for r := 0; r < rows; r++ {
		for c := 0; c < cols; c++ {
			if grid[r][c] == '@' && countNeighbors(grid, r, c, rows, cols) < 4 {
				part1++
			}
		}
	}

	// Part 2: iteratively remove accessible rolls until none remain
	part2 := 0
	for {
		var toRemove [][2]int
		for r := 0; r < rows; r++ {
			for c := 0; c < cols; c++ {
				if grid[r][c] == '@' && countNeighbors(grid, r, c, rows, cols) < 4 {
					toRemove = append(toRemove, [2]int{r, c})
				}
			}
		}
		if len(toRemove) == 0 {
			break
		}
		for _, pos := range toRemove {
			grid[pos[0]][pos[1]] = '.'
		}
		part2 += len(toRemove)
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
