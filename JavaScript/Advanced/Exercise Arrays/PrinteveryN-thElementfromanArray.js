function solve(input){
    const inputArr = input;

    let delimiter = Number(inputArr[inputArr.length-1]);
    inputArr.splice(inputArr.length-1);

    const newArray = [];
    for (let index = 0; index < inputArr.length; index+=delimiter) {
        
        newArray.push(inputArr[index]);
    }

    return newArray.join('\n');
}

console.log(solve(['5', 
'20', 
'31', 
'4', 
'20', 
'2']
));