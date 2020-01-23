function solve(input) {
    const inputArr = input;
    let outputArr = [];

    for (var i = 0; i < inputArr.length; i++) {
        inputArr.splice(i, 1);
      }

    outputArr = inputArr.map(x => x * 2).reverse();

    //     for (let index = 0; index < inputArr.length; index++) {

    //         if (index % 2 != 0) {
    //             outputArr.unshift(inputArr[index] * 2);
    //         }
    //     }

         return outputArr.join(' ');
     }

    console.log(solve([3, 0, 10, 4, 7, 3]));