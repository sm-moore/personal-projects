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

func flipThosePancakes(pancakes string) int {
	// Align all the pancakes so that they are all facing the same direction.
	pancakesSlice := strings.Split(pancakes, "")

	// Check to be sure they aren't already aligned
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

func alignPancakes(pancakes []string, flipsSoFar int) ([]string, int) {
	// printMe(pancakes)
	if len(pancakes) == 1 || match(pancakes) {
		return flipMatchingStack(pancakes), flipsSoFar + 1
	}
	// start from the end, move left until symbols dont match
	for i := len(pancakes) - 1; i > 0; i-- {
		if pancakes[i] != pancakes[i-1] {
			// align the left half
			pancakesLeft, newFlipsSoFar := alignPancakes(pancakes[:i], flipsSoFar)
			// determine if aligning the left half caused it to match the right half, or if it needs to be flipped first
			if pancakesLeft[0] != pancakes[i] {
				pancakesLeft = flipMatchingStack(pancakesLeft)
				newFlipsSoFar++
			}
			// append the right half
			newPancakes := append(pancakesLeft, pancakes[i:len(pancakes)]...)
			// all pancakes are aligned
			return newPancakes, newFlipsSoFar
		}
	}
	// they are already aligned
	return pancakes, flipsSoFar

}

// Flips all the pancakes in this stack
// func flipStack(pancakes []string) []string {
// 	newPancakes := pancakes
// 	for i := 0; i <= len(pancakes)/2; i++ {
// 		// flip and swap
// 		left := flip(pancakes[i])
// 		right := flip(pancakes[(len(pancakes)-1)-i])
// 		newPancakes[i] = right
// 		newPancakes[(len(pancakes)-1)-i] = left
// 	}
// 	return newPancakes
// }

func printMe(str []string) {
	for _, s := range str {
		fmt.Printf("%v, ", s)
	}
	println()
}

func flipMatchingStack(pancakes []string) []string {
	newPancakes := pancakes
	// flip each pancake
	for i := 0; i < len(pancakes); i++ {
		newPancakes[i] = flip(pancakes[i])
	}
	return newPancakes
}

func flip(pancake string) string {
	if pancake == "+" {
		return "-"
	}
	return "+"
}

// Returns true if all pancakes are facing the same direction
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

	t, err := reader.ReadString('\n')
	if err != nil {
		exit(err)
	}

	testCaseCount, err := strconv.Atoi(strings.TrimSpace(t))
	if err != nil {
		exit(err)
	}

	results := []int{}

	for i := 0; i < testCaseCount; i++ {
		testCase, err := reader.ReadString('\n')
		if err != nil {
			exit(err)
		}

		results = append(results, flipThosePancakes(testCase))
	}

	for i, result := range results {
		fmt.Printf("Case #%v: %v\n", i+1, result)
	}
}
