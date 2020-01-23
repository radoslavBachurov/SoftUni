// function solve(input) {
//     const inputMatrix = input;
//     let max = Number.MIN_VALUE;

//     for (let index = 0; index < input.length; index++) {

//         inputMatrix[index].sort((a, b) => b - a);

//         if (inputMatrix[index][0] > max) {
//             max = inputMatrix[index][0];
//         }
//     }

//     if(max == Number.MIN_VALUE)
//     {
//         max = [];
//     }

//     return max;
// }

// console.log(solve([]));
function solve(array) {
    console.log(Math.max(...array.flat(1)));
}

solve([]);