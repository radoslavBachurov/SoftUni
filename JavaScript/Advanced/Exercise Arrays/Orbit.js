function solve(input) {
    let rows = input[0];
    let colls = input[1];
    let y = input[2];
    let x = input[3];

    const matrix = [];
    for (let index = 0; index < rows; index++) {
        matrix[index] = [];
    }
    matrix[y][x] = 1;

    let depth = 2;
    while (isNotFull(matrix, rows, colls)) {

        for (let row = 0; row < rows; row++) {

            for (let coll = 0; coll < colls; coll++) {

                if (matrix[row][coll] == depth - 1) {
                    if (row - 1 >= 0 && matrix[row - 1][coll] == null) {
                        matrix[row - 1][coll] = depth;

                    }
                    if (coll - 1 >= 0 && row - 1 >= 0 && matrix[row - 1][coll - 1] == null) {
                        matrix[row - 1][coll - 1] = depth;
                    }
                    if (coll + 1 < colls && row - 1 >= 0 && matrix[row - 1][coll + 1] == null) {
                        matrix[row - 1][coll + 1] = depth;
                    }
                    if (row + 1 < matrix.length && matrix[row + 1][coll] == null) {
                        matrix[row + 1][coll] = depth;

                    }
                    if (coll - 1 >= 0 && row + 1 < matrix.length && matrix[row + 1][coll - 1] == null) {
                        matrix[row + 1][coll - 1] = depth;
                    }
                    if (coll + 1 < colls && row + 1 < matrix.length && matrix[row + 1][coll + 1] == null) {
                        matrix[row + 1][coll + 1] = depth;
                    }
                    if (coll + 1 < colls && matrix[row][coll + 1] == null) {
                        matrix[row][coll + 1] = depth;
                    }
                    if (coll - 1 >= 0 && matrix[row][coll - 1] == null) {
                        matrix[row][coll - 1] = depth;
                    }
                }
            }
        }

        depth++;
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

console.log(solve([5, 1, 0, 0]))

// function solve(input) {
//     let rows = input[0];
//     let cols = input[1];
//     let starRow = input[2];
//     let starCol = input[3];

//     let matrix = [];
//     for (let i = 0; i < rows; i++) {
//         matrix.push([]);
//     }

//     for (let row = 0; row < rows; row++) {
//         for (let col = 0; col < cols; col++) {
//             matrix[row][col] = Math.max(Math.abs(row - starRow), Math.abs(col - starCol)) + 1;
//         }
//     }
//     let toreturn = '';
//     for (let index = 0; index < matrix.length; index++) {
//         toreturn += `${matrix[index].join(' ')}\n`;
//     }

//     return toreturn;

// }

// console.log(solve([5, 1, 0, 0]))