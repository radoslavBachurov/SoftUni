function solve(input) {

    let number = input.shift();

    while (input.length > 0) {

        let command = input.shift();
        switch (command) {
            case 'chop':
                number /= 2;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number = number - (number * 0.2);
                break;
            case 'spice':
                number += 1;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
            default:
                break;
        }

        console.log(number);
    }

    //     chop - divide the number by two
    // dice - square root of number
    // spice - add 1 to number
    // bake - multiply number by 3
    // fillet - subtract 20% from number
}

solve(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);