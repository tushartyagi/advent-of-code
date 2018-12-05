use std::io::{self, BufReader, BufRead};
use std::fs::File;
use std::collections::{HashSet, HashMap};

extern crate time;
use time::PreciseTime;

fn get_input(s: &str) -> i32 {
    i32::from_str_radix(s, 10).unwrap()
}

fn solve_11() -> i32 {
    let path = "inputs/1.txt";
    let f = File::open(path).unwrap();
    let f = BufReader::new(f);

    let mut state: i32 = 0;
    
    for line in f.lines() {
        state = state + get_input(&line.unwrap())
    }

    state
}

fn solve_12() -> i32 {
    let mut frequencies: HashSet<i32> = HashSet::new();
    let path = "inputs/1.txt";
    let mut found = false;
    let mut state: i32 = 0;
    let mut count: i32 = 0;
    
    loop {
        let f = File::open(path).unwrap();
        let f = BufReader::new(f);
        //println!("Reading file {}", count);
                
        for line in f.lines() {
            state = state + get_input(&line.unwrap());
            if frequencies.contains(&state) {
                return state
            }
            frequencies.insert(state);                
        }

        count += 1;
    }
}

// Find the number of times a character appears in a string
fn char_frequencies(s: &str) -> HashMap<char, i32> {

    let mut map = HashMap::new();
    for c in s.chars() {
        let count = map.entry(c).or_insert(0);
        *count += 1;
    }
    map
}

fn solve_21() -> i32 {
    0
}

fn main() {
    let start = PreciseTime::now();
    let end = PreciseTime::now();
    let map = char_frequencies("bababc");
    for (key, value) in map.iter(){
        println!("{}, {}", key, value);
    }
}
