package main

import (
	"os"
	"testing"
)

func TestSolve(t *testing.T) {
	data, err := os.ReadFile("example.txt")
	if err != nil {
		t.Fatalf("failed to read example.txt: %v", err)
	}

	part1, part2 := Solve(string(data))

	if part1 != 357 {
		t.Errorf("Part 1: got %d, want 357", part1)
	}
	if part2 != 3121910778619 {
		t.Errorf("Part 2: got %d, want 3121910778619", part2)
	}
}
