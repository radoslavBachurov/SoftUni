function solve(input) {

    let inputArr = input;
    let sortedArr = [];

    function sortArr(inputArr) {
        let sortedArr = [];
        
        for (let index = 0; index < inputArr.length; index++) {

            if (inputArr[index] < 0) {

                sortedArr.unshift(inputArr[index]);
            }
            else if (inputArr[index] >= 0) {

                sortedArr.push(inputArr[index])
            }
           
        }

        return sortedArr;
    }

    sortedArr = sortArr(inputArr);
    return sortedArr.join('\n');;

}

console.log(solve([0, 3, -2, 0, -1, 0]));