function solve(input) {
    const inputArr = input;
    let numberRotations = inputArr.pop();

    for (let index = 0; index < numberRotations; index++) {

        let toAdd = inputArr.pop();;
        inputArr.unshift(toAdd);
    }

    return inputArr.join(' ');
}

console.log(solve([]));