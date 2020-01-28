function solve(input) {
    let inputArr = input;
    let juiceStore = {};
    let ordered = {};
    for (let index = 0; index < inputArr.length; index++) {
        let currJuiceArr = inputArr[index].split(' => ').filter(x => x != '');

        let currJuice = currJuiceArr[0];
        let amount = +currJuiceArr[1];

        if (juiceStore[currJuice] == undefined) {
            juiceStore[currJuice] = amount;
        }
        else {
            juiceStore[currJuice] += amount
        }

        if (juiceStore[currJuice] >= 1000) {
            ordered[currJuice] = juiceStore[currJuice];
        }
    }


    let toReturn = '';
    for (const key in ordered) {

        if (ordered[key] >= 1000)
            toReturn += `${key} => ${parseInt(ordered[key] / 1000)}\n`
    }
    return toReturn;
}

console.log(solve(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']

));