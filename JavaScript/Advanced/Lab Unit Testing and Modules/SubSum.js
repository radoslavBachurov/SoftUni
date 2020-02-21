function sum(array, firstIndex, secondIndex) {
    
    let startInx = firstIndex;
    let endInx = secondIndex;
   
    if (!Array.isArray(array)) {
        return NaN;
    }

    if (firstIndex < 0) {
        startInx = 0;
    }
    if (secondIndex >= array.length) {
        endInx = array.length - 1;
    }

    let sum = array.reduce(function (a, b, i) {
        if (i >= startInx && i <= endInx) {
            return a + Number(b)
        }
        return a;
    }
        , 0);

    return sum;
}

module.exports = sum;