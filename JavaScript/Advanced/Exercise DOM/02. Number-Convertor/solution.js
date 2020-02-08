function solve() {

    let selectMenuTo = document.getElementById('selectMenuTo');
    let inputValue = document.getElementById('input');

    selectMenuTo.innerHTML =
        `
    <option selected value=""></option>
    <option selected value="binary">Binary</option>
    <option selected value="hexadecimal">Hexadecimal</option>
    `;

    let convertButton = document.getElementsByTagName('button')[0];
    convertButton.addEventListener('click', () => {
        let numberToConvert = Number(inputValue.value);
        let convertTo = selectMenuTo.value;
        let converted;

        if (convertTo == 'hexadecimal') {
            converted = numberToConvert.toString(16).toUpperCase();
        }
        else {
            converted = numberToConvert.toString(2);
        }

        document.getElementById('result').value = converted;
    })
}