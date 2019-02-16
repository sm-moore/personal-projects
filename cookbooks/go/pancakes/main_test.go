package main

import (
	"testing"
)

func TestMatch(t *testing.T) {
	if match([]string{"+", "+"}) != true {
		t.Error("Expected match to return true")
	}
	if match([]string{"-", "-"}) != true {
		t.Error("Expected match to return true")
	}
	if match([]string{"-", "-", "-", "-"}) != true {
		t.Error("Expected match to return true")
	}
	if match([]string{"+"}) != true {
		t.Error("Expected match to return true")
	}
	if match([]string{"+", "-"}) != false {
		t.Error("Expected match to return false")
	}
	if match([]string{"+", "-", "-", "-"}) != false {
		t.Error("Expected match to return false")
	}
	if match([]string{"+", "-", "+", "-"}) != false {
		t.Error("Expected match to return false")
	}
}

func TestFlip(t *testing.T) {
	if flip("+") != "-" {
		t.Error("Expected - but got +")
	}
	if flip("-") != "+" {
		t.Error("Expected + but got -")
	}
}

func TestFlipMatchingStack(t *testing.T) {
	if equal(flipMatchingStack([]string{"+"}), []string{"-"}) == false {
		t.Errorf("test 1 failed expected %v, got %v", []string{"-"}, flipMatchingStack([]string{"+"}))
	}
	if equal(flipMatchingStack([]string{"-"}), []string{"+"}) == false {
		t.Errorf("test 2 failed expected %v, got %v", []string{"+"}, flipMatchingStack([]string{"-"}))
	}
	if equal(flipMatchingStack([]string{"-", "-", "-"}), []string{"+", "+", "+"}) == false {
		t.Errorf("test 3 failed expected %v, got %v", []string{"+", "+", "+"}, flipMatchingStack([]string{"-", "-", "-"}))
	}
}

func equal(a, b []string) bool {
	if len(a) != len(b) {
		return false
	}
	for i, v := range a {
		if v != b[i] {
			return false
		}
	}
	return true
}

func TestAlignPancakes(t *testing.T) {
	runTest(t, []string{"-"}, 0, []string{"+"}, 1)
	runTest(t, []string{"-", "-"}, 0, []string{"+", "+"}, 1)
	runTest(t, []string{"-", "-", "+"}, 0, []string{"+", "+", "+"}, 1)
	runTest(t, []string{"-", "+", "-"}, 0, []string{"-", "-", "-"}, 2)
	runTest(t, []string{"+", "-", "+"}, 0, []string{"+", "+", "+"}, 2)
	runTest(t, []string{"-", "+", "-", "+"}, 0, []string{"+", "+", "+", "+"}, 3)
	runTest(t, []string{"+", "+", "-", "+"}, 0, []string{"+", "+", "+", "+"}, 2)
	runTest(t, []string{"+", "+", "+", "+"}, 0, []string{"-", "-", "-", "-"}, 1)
	runTest(t, []string{"-", "+", "+", "-", "-", "+"}, 0, []string{"+", "+", "+", "+", "+", "+"}, 3)
}

func runTest(t *testing.T, startPancakes []string, startFlips int, expectedPancakes []string, expectedFlips int) {
	pancakes, flips := alignPancakes(startPancakes, startFlips)
	if equal(pancakes, expectedPancakes) == false {
		t.Errorf("Expected %v, got %v", expectedPancakes, pancakes)
	}
	if flips != expectedFlips {
		t.Errorf("Expected %v flips, got %v flips", expectedFlips, flips)
	}
}

func TestFlipThosePancakes(t *testing.T) {
	if flips := flipThosePancakes("+"); flips != 0 {
		t.Errorf("test 1 failed expected 0 flips, got %v", flips)
	}
	if flips := flipThosePancakes("-"); flips != 1 {
		t.Errorf("test 2 failed expected 1 flips, got %v", flips)
	}
	if flips := flipThosePancakes("--"); flips != 1 {
		t.Errorf("test 3 failed expected 1 flips, got %v", flips)
	}
	if flips := flipThosePancakes("--+"); flips != 1 {
		t.Errorf("test 4 failed expected 1 flips, got %v", flips)
	}
	if flips := flipThosePancakes("+--"); flips != 2 {
		t.Errorf("test 5 failed expected 2 flips, got %v", flips)
	}
	if flips := flipThosePancakes("+-"); flips != 2 {
		t.Errorf("test 6 failed expected 2 flips, got %v", flips)
	}
	if flips := flipThosePancakes("-+"); flips != 1 {
		t.Errorf("test 7 failed expected 1 flips, got %v", flips)
	}
	if flips := flipThosePancakes("+-+-"); flips != 4 {
		t.Errorf("test 8 failed expected 4 flips, got %v", flips)
	}
	if flips := flipThosePancakes("-+-+"); flips != 3 {
		t.Errorf("test 9 failed expected 3 flips, got %v", flips)
	}
	if flips := flipThosePancakes("--+-"); flips != 3 {
		t.Errorf("test 10 failed expected 3 flips, got %v", flips)
	}
}
