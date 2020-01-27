function solve(input) {
    const inputArr = input;
    const storeDatabase = {};

    for (let index = 0; index < inputArr.length; index++) {
        let currInput = inputArr[index].split(/\s+[-]*[>]*[:]*\s/);
        let town = currInput[0];
        let product = currInput[1];
        let sales = +currInput[2];
        let price = +currInput[3];

        if (storeDatabase[town] == undefined) {
            storeDatabase[town] = {};
            storeDatabase[town][product] = sales * price;
        }
        else if (storeDatabase[town][product] == undefined) {
            storeDatabase[town][product] = sales * price;
        }
        else {
            storeDatabase[town][product] += sales * price;
        }

    }
    let toReturn = '';
    for (const key in storeDatabase) {
        toReturn += `Town - ${key}\n`
        for (const secKey in storeDatabase[key]) {
           toReturn+=`$$$${secKey} : ${storeDatabase[key][secKey]}\n`
        }
    }

    return toReturn;

}

console.log(solve(['Sofia -> Laptops HP -> 200 : 2000',
    'Sofia -> Raspberry -> 200000 : 1500',
    'Sofia -> Audi Q7 -> 200 : 100000',
    'Montana -> Portokals -> 200000 : 1',
    'Montana -> Qgodas -> 20000 : 0.2',
    'Montana -> Chereshas -> 1000 : 0.3']
));