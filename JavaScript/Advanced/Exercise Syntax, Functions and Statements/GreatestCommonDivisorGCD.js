function solve(num1, num2) {
    let bigger = Math.max(num1, num2);

    for (let index = bigger; index >= 0; index--) {

        if (num1 % index == 0 && num2 % index == 0) {
            console.log(index);
            break;
        }
    }
}

solve(2154, 458);