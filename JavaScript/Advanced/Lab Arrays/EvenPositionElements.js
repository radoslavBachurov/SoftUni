function solve(input) {
    let inputArr = input;
    let evenArr = [];

    for (let index = 0; index < inputArr.length; index++) {

        if (index % 2 == 0) {
            evenArr.push(inputArr[index]);
        }

    }

    return evenArr.join(' ');
}

console.log(solve(['20', '30', '40']));