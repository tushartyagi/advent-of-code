use std::io::{self, BufReader, BufRead};
use std::fs::File;
use std::collections::HashMap;

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
    0
}

fn find_char_groups(s: &str) -> HashMap<char, i32> {
    let mut map = HashMap::new();

    for c in s.chars() {
        let count = map.entry(c).or_insert(0);
        *count += 1;
    }
    map
}

// Returns a pair of boolean stating if the hashmap contains a letter
// twice and a letter thrice
fn find_two_and_three(h: &HashMap<char, i32>) -> (bool, bool) {
    let found_twice = if h.iter().any(|(k, v)| { *v == 2 }) { true } else { false };
    let found_thrice = if h.iter().any(|(k, v)| { *v == 3 }) { true } else { false }; 
    (found_twice, found_thrice)
}

fn solve_21() {
    let path = "inputs/2.txt";
    let f = File::open(path).unwrap();
    let f = BufReader::new(f);

    for s in f.lines().map(|l| {find_char_groups(&l.unwrap())}) {
        for (k, v) in s.iter() {
            println!("{}: {}", k, v);
        }
    }
}
    

fn main() {
    //solve_21();
    let m = find_char_groups("ababab");
    m.iter().fold((), |acc, k| {
        match k {
            (k, v) => println!("{}", v)
        }
    });

    let mut h1 = HashMap::new();
    h1.insert('a', 1);
    h1.insert('b', 1);
    h1.insert('c', 3);
    let mut h2 = HashMap::new();
    h2.insert('d', 1);
    h2.insert('e', 2);
    h2.insert('f', 3);
    //let v = vec![h1, h2];

    let (two, three) = find_two_and_three(&h1);
    println!("Two: {} Three: {}", two, three);
    
}
