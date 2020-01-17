function solve(argOne, argTwo, argThree) {
    let firstLenght = [...argOne].length;
    let secondLenght = [...argTwo].length;
    let thirdLenght = [...argThree].length;

    let sum = firstLenght + secondLenght + thirdLenght;
    let average = parseInt(sum / 3)
    console.log(sum);
    console.log(average)
}

solve('chocolate', 'ice cream', 'cake');