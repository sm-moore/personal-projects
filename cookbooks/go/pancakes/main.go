package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"strings"
)

func exit(err error) {
	fmt.Fprintf(os.Stderr, "error: %v\n", err)
	os.Exit(1)
}

// Returns the minimum number of flips required to turn all pancakes right-side-up.
// This algorithm is solved by recursively aligning the pancakes and counting the number of flips required to do so.
func flipThosePancakes(pancakes string) int {
	// Align all the pancakes so that they are all facing the same direction.
	pancakesSlice := strings.Split(pancakes, "")

	// Check to be sure they aren't already aligned.
	if match(pancakesSlice) {
		if pancakesSlice[0] == "-" {
			return 1
		}
		return 0
	}

	alignedPancakes, flips := alignPancakes(pancakesSlice, 0)

	// Are they facing downward? If so, one more flip is required.
	if alignedPancakes[0] == "-" {
		flips++
	}
	return flips
}

// Aligns all pancakes in the stack so that they are all facing one direction. Also tracks the number of flips it takes to do this.
func alignPancakes(pancakes []string, flipsSoFar int) ([]string, int) {
	if len(pancakes) == 1 || match(pancakes) {
		return flipMatchingStack(pancakes), flipsSoFar + 1
	}
	// Start from the end, move left until symbols don't match.
	for i := len(pancakes) - 1; i > 0; i-- {
		if pancakes[i] != pancakes[i-1] {
			// Align the left half.
			pancakesLeft, newFlipsSoFar := alignPancakes(pancakes[:i], flipsSoFar)
			// Determine if left half must be flipped.
			if pancakesLeft[0] != pancakes[i] {
				pancakesLeft = flipMatchingStack(pancakesLeft)
				newFlipsSoFar++
			}
			// Append the right half.
			newPancakes := append(pancakesLeft, pancakes[i:len(pancakes)]...)
			// All pancakes are aligned.
			return newPancakes, newFlipsSoFar
		}
	}
	// Pancakes are already aligned.
	return pancakes, flipsSoFar

}

// Given a stack of pancakes that are matching, flip them.
// Note: matching pancake stacks that are flipped don't need to be reversed,
// this shortcut saves a bit of stack space.
func flipMatchingStack(pancakes []string) []string {
	newPancakes := pancakes
	for i := 0; i < len(pancakes); i++ {
		newPancakes[i] = flip(pancakes[i])
	}
	return newPancakes
}

// Flips a single pancake
func flip(pancake string) string {
	if pancake == "+" {
		return "-"
	}
	return "+"
}

// Returns true if all pancakes are facing the same direction.
func match(pancakes []string) bool {
	if len(pancakes) == 1 {
		return true
	}
	for i := len(pancakes) - 1; i > 0; i-- {
		if pancakes[i] != pancakes[i-1] {
			return false
		}
	}
	return true
}

func main() {
	reader := bufio.NewReader(os.Stdin)
	// First line contains the number of test cases.
	t, err := reader.ReadString('\n')
	if err != nil {
		exit(err)
	}
	testCaseCount, err := strconv.Atoi(strings.TrimSpace(t))
	if err != nil {
		exit(err)
	}

	// Read in the correct number of test cases.
	results := []int{}
	for i := 0; i < testCaseCount; i++ {
		testCase, err := reader.ReadString('\n')
		if err != nil {
			exit(err)
		}
		// Run the algorithm and store it to be printed later.
		results = append(results, flipThosePancakes(strings.TrimSpace(testCase)))
	}

	// Print all results.
	for i, result := range results {
		fmt.Printf("Case #%v: %v\n", i+1, result)
	}
}
