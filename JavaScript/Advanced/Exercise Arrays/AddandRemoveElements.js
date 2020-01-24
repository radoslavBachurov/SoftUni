function solve(input) {
    let initialNumber = 0;
    const inputArr = input;
    const numberArr = [];

    for (let index = 0; index < inputArr.length; index++) {
        switch (inputArr[index]) {
            case 'add':
                initialNumber++;
                numberArr.push(initialNumber);
                break;

            case 'remove':
                initialNumber++;
                if (numberArr.length != 0) {
                    numberArr.splice(numberArr.length - 1);
                }
                break;
        }
    }

    if (numberArr.length == 0) {
        numberArr[0] = 'Empty';
    }

    return numberArr.join('\n');
}

console.log(solve(['add', 
'add', 
'remove', 
'add', 
'add']
));