pub fn solve(input: &str) -> String {
    let throws = get_throws(input);

    let mut sum = 0;
    let mut result = String::new();

    for throw in &throws {
        sum += throw.sum();
        result += &sum.to_string();
        result += ",";
    }

    let result = &result[..result.len() - 1];

    result.to_string()
}

fn get_throws(input: &str) -> Vec<Throw> {
    let parts: Vec<&str> = input.split(':').collect();

    let n: usize = parts[0].parse().unwrap();

    let parts = parts[1].split(',');

    let mut numbers: Vec<usize> = vec![];

    for part in parts {
        let x: usize = part.parse().unwrap();
        numbers.push(x);
        if x == 10 {
            numbers.push(0);
        }
    }

    if numbers.len() % 2 == 1 {
        numbers.push(0);
    }

    let mut throws: Vec<Throw> = vec![];

    for i in (0..numbers.len()).step_by(2) {
        let throw = Throw::new(numbers[i], numbers[i + 1]);
        throws.push(throw)
    }

    calculate_bonus(&mut throws);

    let throws = &throws[..n];
    let throws: Vec<Throw> = throws.to_owned();

    throws
}

fn calculate_bonus(throws: &mut [Throw]) {
    for i in 0..throws.len() - 1 {
        if throws[i].strike {
            throws[i].bonus = throws[i + 1].sum();
            if throws[i + 1].strike && i + 2 < throws.len() {
                throws[i].bonus += throws[i + 2].first;
            }
        } else if throws[i].spare {
            throws[i].bonus = throws[i + 1].first;
        }
    }
}

#[derive(Debug, Clone)]
struct Throw {
    first: usize,
    second: usize,
    bonus: usize,
    strike: bool,
    spare: bool,
}

impl Throw {
    fn new(first: usize, second: usize) -> Self {
        let mut strike = false;
        let mut spare = false;

        if first == 10 {
            strike = true;
        } else if first + second == 10 {
            spare = true;
        }

        Throw {
            first,
            second,
            bonus: 0,
            strike,
            spare,
        }
    }

    fn sum(&self) -> usize {
        self.first + self.second + self.bonus
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn normal() {
        let result = solve("10:1,4,4,5,6,4,5,5,10,0,1,7,3,6,4,10,2,8,6");
        assert_eq!(result, "5,14,29,49,60,61,77,97,117,133".to_string());
    }

    #[test]
    fn just_strikes() {
        let result = solve("10:10,10,10,10,10,10,10,10,10,10,10,10");
        assert_eq!(result, "30,60,90,120,150,180,210,240,270,300".to_string());
    }
}
