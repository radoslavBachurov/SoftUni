function solve() {

    let values = document.querySelector('.keys');
    let exOutput = document.getElementById("expressionOutput");
    let resultOutput = document.getElementById('resultOutput');
    let clear = document.querySelector('.clear');
    let operands = ['/', '*', '-', '+'];

    let mathOperations = {
        '/': (one, second) => one / second,
        '*': (one, second) => one * second,
        '-': (one, second) => one - second,
        '+': (one, second) => one + second
    }
    
    clear.addEventListener('click', () => {
        resultOutput.innerHTML = '';
        exOutput.innerHTML = '';
    })
    values.addEventListener('click', (ev) => {
        let value = ev.target.value;

        if (value == '=') {
            let expression = exOutput.innerHTML.split(' ').filter(x => x != '');
            let firstElement = Number(expression[0]);
            let secondElement = expression[1];
            let thirdElement = Number(expression[2]);

            if (thirdElement === undefined) {
                resultOutput.innerHTML = 'NaN';
                return;
            }

            resultOutput.innerHTML = mathOperations[secondElement](firstElement, thirdElement);
            return;
        }

        if (operands.includes(value)) {
            exOutput.innerHTML += ` ${value} `;
            return;
        }

        exOutput.innerHTML += value;
    })
}