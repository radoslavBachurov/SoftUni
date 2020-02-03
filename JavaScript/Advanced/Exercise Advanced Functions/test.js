var person = (function () {
    var initialString = '';

    function append(input) {
        initialString += input;
    }

    function print() {
        console.log(initialString);
    }

    return {
        append,
        print
    }
})();


person.append('test2');


person.print();