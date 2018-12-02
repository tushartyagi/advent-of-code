use std::io::{self, BufReader, BufRead};
use std::fs::File;

fn get_input(s: &str) -> i64 {
    i64::from_str_radix(s, 10).unwrap()
}

fn solve_11() -> i64 {
    let path = "inputs/1.txt";
    let f = File::open(path).unwrap();
    let f = BufReader::new(f);

    let mut state: i64 = 0;
    
    for line in f.lines() {
        state = state + get_input(&line.unwrap())
    }

    state
}

fn solve_12() -> i64 {
}

fn main() {
    let m = solve_11();
    println!("{}", m);
}
