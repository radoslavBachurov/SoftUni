function result(input) {

    let startNumber = input;

    return function (number) {
        return startNumber + number;
    }

}

let ca = result(4);
console.log(ca(5));
