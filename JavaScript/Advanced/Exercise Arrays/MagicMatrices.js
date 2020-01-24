function solve(input) {
    const inputArr = input;

    var rowSum = inputArr.map(r => r.reduce((a, b) => a + b));
    var colSum = inputArr.reduce((a, b) => a.map((x, i) => x + b[i]));

    const allSums = rowSum.concat(colSum);
    let isMagic = allSums.every((val, i, arr) => val === arr[0])

    return isMagic;
}

console.log(solve([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]
));