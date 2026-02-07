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

	part1, _ := Solve(string(data))

	if part1 != 13 {
		t.Errorf("Part 1: got %d, want 13", part1)
	}
}
