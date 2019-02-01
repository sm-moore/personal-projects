extern crate rand;

use std::io;
use std::cmp::Ordering;
use rand::Rng;

fn main() {
    println!("Guess the number!");
    println!("Enter your guess.");

    // all objects are immutatble by default? only strings are?
    // mut = mutable.
    let mut guess = String::new();

    io::stdin().read_line(&mut guess).expect("unable to read guess.");

    let guess: u32 = guess.trim().parse().expect("please enter a number.");

    println!("Your guess is {}", guess);

    let secret_number = rand::thread_rng().gen_range(1, 101);

    match guess.cmp(&secret_number) {
        Ordering::Less => println!("Too small!"),
        Ordering::Greater => println!("Too big!"),
        Ordering::Equal => println!("Congratulations! You guessed the correct number!"),
    }

    println!("The correct number is: {}", secret_number);
}
