function solve(input) {
    const strArray = input;

    const inputMatrix = [];
    const firstDiagonal = [];
    const secondDiagonal = [];

    for (let index = 0; index < strArray.length; index++) {
        let toAdd = strArray[index].split(' ').map(Number);

        inputMatrix[index] = toAdd;
    }

    for (let index = 0; index < inputMatrix.length; index++) {
        if (index == inputMatrix[index].length) {
            break;
        }
        firstDiagonal.push(inputMatrix[index][index]);
    }

    let row = 0;
    for (let coll = inputMatrix.length - 1; coll >= 0; coll--) {

        secondDiagonal.push(inputMatrix[row][coll]);
        row++;
    }

    let firstSum = firstDiagonal.reduce((acc, curr) => acc + curr, 0);
    let seconSum = secondDiagonal.reduce((acc, curr) => acc + curr, 0);

    if (firstSum == seconSum) {
        for (let index = 0; index < inputMatrix.length; index++) {
            inputMatrix[index].fill(firstSum);
        }

        for (let index = 0; index < inputMatrix.length; index++) {
            if (index == inputMatrix[index].length) {
                break;
            }
            inputMatrix[index][index] = firstDiagonal[index];
        }

        let row = 0;
        for (let coll = inputMatrix.length - 1; coll >= 0; coll--) {

            inputMatrix[row][coll] = secondDiagonal[row];
            row++;
        }

        let toreturn = '';
        for (let index = 0; index < inputMatrix.length; index++) {
            toreturn += `${inputMatrix[index].join(' ')}\n`;
        }

        return toreturn;
    }

    let toreturn = '';
    for (let index = 0; index < inputMatrix.length; index++) {
        toreturn += `${inputMatrix[index].join(' ')}\n`;
    }

    return toreturn;
}

console.log(solve(['5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']
));