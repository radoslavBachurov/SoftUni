// function solve(input) {
//     const inputArr = input;
//     const increasingArr = [];

//     if (inputArr.length > 0) {
//         let toAdd = inputArr.shift();
//         increasingArr.push(toAdd);
//     }

//     while (inputArr.length > 0) {
//         let toAdd = inputArr.shift();
//         if (increasingArr[increasingArr.length - 1] <= toAdd) {
//             increasingArr.push(toAdd);
//         }
//     }

//     return increasingArr.join('\n');
// }

// console.log(solve([1,
//     3,
//     8,
//     4,
//     10,
//     12,
//     3,
//     2,
//     24]

// ));

function solve(numArr){
    let finalArr = numArr.reduce((acc, curr)=>{
            if(curr>=Math.max(...acc)){
                acc.push(curr);
            }
        return acc;
        }, []).forEach(element => {
            console.log(element);      
        });
        
    }
    solve([1,
        3,
        8,
        4,
        10,
        12,
        3,
        2,
        24]);