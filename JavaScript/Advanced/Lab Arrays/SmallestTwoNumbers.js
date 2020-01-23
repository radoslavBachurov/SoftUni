function solve(input) {

    const inputArr = input;
    inputArr.sort(((a, b) => a - b));
    inputArr.splice(2);
    
    return inputArr.join(' ');
}

console.log(solve([30, 15, 50, 5]));