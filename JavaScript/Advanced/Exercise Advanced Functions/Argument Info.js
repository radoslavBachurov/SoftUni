function solve(...data) {
    let args = data;
    let typeCounter = {};

    for (const el of args) {
        if (!typeCounter[typeof (el)]) {
            typeCounter[typeof (el)] = 0;
        }
        typeCounter[typeof (el)]++;
        console.log(`${typeof (el)}: ${el}`);
    }

    let typeCounterArr = Object.entries(typeCounter).sort((a, b) => b[1] - a[1]);

    typeCounterArr.forEach(el => {
        console.log(`${el[0]} = ${el[1]}`)
    });
}

solve('cat', 42, function () { console.log('Hello world!'); });