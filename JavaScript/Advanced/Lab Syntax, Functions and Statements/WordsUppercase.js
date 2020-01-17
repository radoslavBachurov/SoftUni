function solve(input) {
    const re = /[A-Za-z]+/g;
    let extracted = input.match(re);

    for (let index = 0; index < extracted.length; index++) {

        extracted[index] = extracted[index].toUpperCase();
    }
    console.log(extracted.join(', '));
}

solve('Hi, how are you?');