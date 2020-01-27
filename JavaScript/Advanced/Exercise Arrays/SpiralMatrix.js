function solve(numberRows, numberColls) {
    let rows = numberRows;
    let colls = numberColls;
    const matrix = [];
    for (let index = 0; index < rows; index++) {
        matrix[index] = [];
    }

    matrix[0][0] = 1;
    let index = 2;
    let currRow = 0;
    let currColl = 0;
    while (isNotFull(matrix, rows, colls)) {
        while (currColl + 1 < colls && matrix[currRow][currColl + 1] == null) {
            matrix[currRow][currColl + 1] = index;
            index++;
            currColl++;
        }
        while (currRow + 1 < rows && matrix[currRow + 1][currColl] == null) {
            matrix[currRow + 1][currColl] = index;
            index++;
            currRow++;
        }
        while (currColl - 1 >= 0 && matrix[currRow][currColl - 1] == null) {
            matrix[currRow][currColl - 1] = index;
            index++;
            currColl--;
        }
        while (currRow - 1 < rows && matrix[currRow - 1][currColl] == null) {
            matrix[currRow - 1][currColl] = index;
            index++;
            currRow--;
        }
    }

    let toreturn = '';
    for (let index = 0; index < matrix.length; index++) {
        toreturn += `${matrix[index].join(' ')}\n`;
    }
    return toreturn;

    function isNotFull(matrix, rows, colls) {

        for (let i = 0; i < rows; i++) {
            for (let index = 0; index < colls; index++) {
                if (matrix[i][index] == null) {
                    return true;
                }
            }
        }
        return false;
    }
}

console.log(solve(5,5));