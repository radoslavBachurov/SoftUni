function solve(lenght, accLenght) {
    const arr = [1];

    for (let index = 0; index < lenght-1; index++) {
        let startValue = arr.length - accLenght;
        if (startValue < 0) {
            startValue = 0;
        }

        let newValue = arr.reduce((accumulator, currentValue, index) => {
            if (index >= startValue) {
                return accumulator + currentValue;
            } else {
                return 0;
            }
        },0);

        arr.push(newValue);
    }

    return arr.join(' ');
}

console.log(solve(8, 2));