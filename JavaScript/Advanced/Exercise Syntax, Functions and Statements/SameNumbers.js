function solve(number) {
    let same = true;
    let sum = 0;

    let firstLast = number % 10;
    number = parseInt(number / 10);
    sum += firstLast;

    while (number != 0) {
        let last = number % 10;
        number = parseInt(number / 10);
        sum += last;

        if (last != firstLast) {
            same = false;
        }

        firstLast = last;
    }

    console.log(same);
    console.log(sum);
}

solve(1234);