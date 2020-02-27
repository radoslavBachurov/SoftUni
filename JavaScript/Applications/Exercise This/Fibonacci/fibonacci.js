function fibonator() {
    let lastNumberOne = 1;
    let lastNumberTwo = 0;

    return function generator() {
        let toReturn = lastNumberOne + lastNumberTwo;
        let copyNumberTwo = lastNumberTwo;
        lastNumberTwo = lastNumberTwo + lastNumberOne;
        lastNumberOne = copyNumberTwo;

        return toReturn;
    }
}

let test1 = fibonator();
console.log(test1());
console.log(test1());
console.log(test1());
console.log(test1());
console.log(test1());



