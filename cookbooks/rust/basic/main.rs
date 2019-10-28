
fn main() {
    println!("Hello World!");
}

// 3(d_{1}+d_{4}+d_{7})+7(d_{2}+d_{5}+d_{8})+(d_{3}+d_{6}+d_{9})\mod 10=0.\,

fn check_routing_number(rn: &str) -> bool {
    // let d1 = rn[0];
    return 3 * (rn.char_at(0).to_digit(10)) == 0
    // return true;
}