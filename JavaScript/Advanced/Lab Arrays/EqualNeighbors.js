function solve(input) {
    const inputArr = input;

    let same = 0;

    for (let row = 0; row < inputArr.length; row++) {

        for (let coll = 0; coll < inputArr[row].length; coll++) {

            if (row - 1 >= 0) {
                if (inputArr[row][coll] == inputArr[row - 1][coll]) {
                    same++;
                }
            }
            if (row + 1 < inputArr.length) {
                if (inputArr[row][coll] == inputArr[row + 1][coll]) {
                    same++;
                }
            }
            if (coll + 1 < inputArr.length) {
                if (inputArr[row][coll] == inputArr[row][coll + 1]) {
                    same++;
                }
            }
            if (coll - 1 >= 0) {
                if (inputArr[row][coll] == inputArr[row][coll - 1]) {
                    same++;
                }
            }

        }
    }

    return same/2;
}

console.log(solve([['2', '2', '5', '7', '4'],
                   ['4', '0', '5', '3', '4'],
                   ['2', '5', '5', '4', '2'],
                   ]));