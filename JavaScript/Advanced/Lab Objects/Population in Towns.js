function solve(input) {
    let inputArr = input;
    let allElements = {};
    for (let index = 0; index < inputArr.length; index++) {
        let pairArr = inputArr[index].split(' <-> ');

        if (allElements[pairArr[0]] == undefined) {
            allElements[pairArr[0]] = +pairArr[1];
        }
        else {
            allElements[pairArr[0]] += +pairArr[1];
        }
    }

    return allElements;
}

console.log(solve(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']

));