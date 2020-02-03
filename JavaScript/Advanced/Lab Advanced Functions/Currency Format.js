function currencyFormatter(separator, symbol, symbolFirst, value) {
    let result = Math.trunc(value) + separator;
    result += value.toFixed(2).substr(-2, 2);
    if (symbolFirst) return symbol + ' ' + result;
    else return result + ' ' + symbol;
}

function getFormatter(formatter) {
    let curFormatter = formatter;

    function myFormatter(value) {
        let separator = ',';
        let symbol = '$';
        let bool = true;

        return curFormatter(separator, symbol, bool, value);
    }

    return myFormatter;
}

let dollarFormatter = result(currencyFormatter);
console.log(dollarFormatter(5345));   // $ 5345,00
console.log(dollarFormatter(3.1429)); // $ 3,14
console.log(dollarFormatter(2.709));  // $ 2,71

