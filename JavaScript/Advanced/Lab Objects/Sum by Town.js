function solve(input) {
    let inputArr = input;
    const dictionary = {};

    for (let index = 0; index < inputArr.length; index += 2) {
        if (dictionary[inputArr[index]] !== undefined){
            dictionary[inputArr[index]] += +inputArr[index + 1];
        }
        else{
            dictionary[inputArr[index]] = +inputArr[index + 1];
        }
            
    }

    return JSON.stringify(dictionary);
}

console.log(solve(['Sofia',
    '20',
    'Varna',
    '3',
    'Sofia',
    '5',
    'Varna',
    '4']
));