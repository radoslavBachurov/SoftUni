function solve(input) {
    const inputArr = input[0].split(/\W+/).filter(function (el) {
        return el != '';
    });;

    let elements = {};
    for (let index = 0; index < inputArr.length; index++) {

        if (elements[inputArr[index]] == undefined) {
            elements[inputArr[index]] = 1;
        }
        else {
            elements[inputArr[index]] += 1;
        }
    }

    return JSON.stringify(elements);
}

console.log(solve(['JS devs use Node.js for server-side JS.-- JS for devs']));