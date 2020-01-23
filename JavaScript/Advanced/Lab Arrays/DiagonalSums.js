function solve(input) {
    const inputMatrix = input;
    let firstDiagonalSum = 0;
    let secondtDiagonalSum = 0;

    for (let i = 0; i < inputMatrix.length; i++) {

        firstDiagonalSum += inputMatrix[i][i]

    }

    let rowIterator = inputMatrix.length - 1;
    for (let i = 0; i < inputMatrix.length; i++) {

        secondtDiagonalSum += inputMatrix[i][rowIterator]
        rowIterator--;
    }

    return (`${firstDiagonalSum} ${secondtDiagonalSum}`)
}

console.log(solve([[20, 40],
[10, 60]]));