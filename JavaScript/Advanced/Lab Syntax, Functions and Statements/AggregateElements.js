function solve(input) {
    let sum = input.reduce((a, b) => a + b, 0);
    let sumInverse = input.reduce((a, b) => a + 1 / b, 0);
    let concat = '';

    for (let index = 0; index < input.length; index++) {

        concat += input[index];
    }

    console.log(sum);
    console.log(sumInverse);
    console.log(concat);
}

solve([1, 2, 3]);