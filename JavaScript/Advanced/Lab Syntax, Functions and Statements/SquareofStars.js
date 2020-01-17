function solve(input) {

    let arg = input;

    if (!arg) {
        arg = 5;
    }

    let toPrint = '';

    for (let index = 0; index < arg; index++) {
        toPrint += '* '
    }

    for (let index = 0; index < arg; index++) {

        console.log(toPrint.trim());
    }

}

solve(3);