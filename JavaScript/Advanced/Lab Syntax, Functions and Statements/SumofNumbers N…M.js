function solve(first, last) {
    let start = Number(first);
    let finish = Number(last);

    let sum = 0;
    for (let index = start; index <= finish; index++) {

        sum += index;
    }

    console.log(sum);
}

solve('1', '5');