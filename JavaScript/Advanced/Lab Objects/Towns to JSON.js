function solve(input) {
    let inputArr = input;
    const objOutput = [];

    for (let index = 0; index < inputArr.length; index++) {
        const inputSplitted = inputArr[index].split(/\s*[|]\s*/).filter(function (el) {
            return el != '';
        });
        if (index == 0) {
            var propOne = inputSplitted[0];
            var propTwo = inputSplitted[1];
            var propThree = inputSplitted[2];
        }
        else {
            let object = {};
            object[propOne] = inputSplitted[0];
            object[propTwo] = parseFloat(parseFloat(inputSplitted[1]).toFixed(2));;
            object[propThree] = parseFloat(parseFloat(inputSplitted[2]).toFixed(2));;
            objOutput.push(object);
        }

    }

    return JSON.stringify(objOutput);
}


console.log(solve(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
));