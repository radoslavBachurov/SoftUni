function solve() {
    let select1;
    let select2;
    let select3;

    let sumEngine = {
        'init': (sel1, sel2, result) => {
            select1 = document.querySelector(sel1);
            select2 = document.querySelector(sel2);
            select3 = document.querySelector(result);
        },

        'add': () => {
            let firstValue = Number(select1.value);
            let secondValue = Number(select2.value);
            select3.value = firstValue + secondValue;
        },

        'subtract': () => {
            let firstValue = Number(select1.value);
            let secondValue = Number(select2.value);
            select3.value = firstValue - secondValue;
        }
    }

    return sumEngine;
}