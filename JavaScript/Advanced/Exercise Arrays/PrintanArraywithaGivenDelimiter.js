function solve(input){
let inputArr = input;

let delimiter = inputArr[inputArr.length-1];
inputArr.splice(inputArr.length-1);

return inputArr.join(delimiter);
}

console.log(solve(['How about no?', 
'I',
'will', 
'not', 
'do', 
'it!', 
'_']
));