use std::io;
// fn swap (list: &mut Vec<String>, first: usize, second: usize){
//     let first_elem = list[first].clone();
//     let second_elem = list[second].clone();
//     list[first] = second_elem;
//     list[second] = first_elem;
// }

fn merge (list: Vec<String>, start_idx: usize, start_second_idx: usize, stop_idx: usize) -> Vec<String> {
    let mut new: Vec<String> = Vec::new();
    let mut current = start_idx;
    let mut second = start_second_idx;
    while current <= stop_idx {

        if current >= start_second_idx {
            //push all elements from start_second on.
            new.push(list[start_second_idx].clone());
            second += 1;
        }
        if second >= stop_idx {
            //push all elements from current on.
            new.push(list[current].clone());
            current += 1;
        }
        if list[current] >= list[start_second_idx]{
            //swap(list, current, start_second_idx);
            new.push(list[start_second_idx].clone());
            second += 1;
        }
        else {
            //swap(list, start_second_idx, current);
            new.push(list[current].clone());
            current += 1;
        }
    }
    new
}

fn merge_sort(list: Vec<String>, list_length: usize) -> Vec<String> {
    // let mut new = Vec::new();
    merge_sort_recur(list, 0, list_length-1);
}

fn merge_sort_recur(list: Vec<String>, start_idx: usize, stop_idx: usize) -> Vec<String> {
    if stop_idx - start_idx <= 0 {
        return;
    }
    let mid = start_idx + (stop_idx - start_idx)/2;
    merge_sort_recur(list, start_idx, mid);//left
    merge_sort_recur(list, mid + 1, stop_idx);//right
    merge(list, start_idx, mid + 1,  stop_idx)
}


fn main() {
    let mut items = Vec::new();

    let mut count = String::new();

    println!("How many items are in your list?");
    io::stdin().read_line(&mut count).expect("unable to read item count.");

    let count: usize = count.trim().parse().expect("please enter an integer.");

    for _ in 0..count {
        let mut item = String::new();
        io::stdin().read_line(&mut item).expect("unable to read guess.");
        items.push(item);
    }

    println!("\nYour list:");
    for idx in 0..count {
        let len = (items[idx].len())-1;
        let sub = &items[idx][..len];
        println!("{}", sub);
    }
}
