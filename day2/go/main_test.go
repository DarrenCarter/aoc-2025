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

	if part1 != 1227775554 {
		t.Errorf("Part 1: got %d, want 1227775554", part1)
	}
	_ = part2 // Part 2 not yet available
}
