function solve(input) {
    let inputArr = input;
    const storeInfo = {};
    const allProducts = [];

    for (let index = 0; index < inputArr.length; index++) {
        let currPair = inputArr[index].split(/\s[|]\s/);
        let town = currPair[0];
        let product = currPair[1];
        let price = +currPair[2];

        let obj = {};
        obj.price = price;
        obj.town = town;
        obj.product = product;
        allProducts.push(obj);

        if (storeInfo[product] == undefined) {
            storeInfo[product] = obj;
        }
        else if (storeInfo[product].town == obj.town) {
            storeInfo[product] = obj;
        }
        else if (storeInfo[product].price > obj.price) {
            storeInfo[product] = obj;
        }

        for (let index = 0; index < allProducts.length; index++) {
            if (allProducts[index].price == storeInfo[product].price 
                && allProducts[index].product == storeInfo[product].product) {
                storeInfo[product] = allProducts[index];
                break;
            }
        }
    }

    let toreturn = '';
    for (const key in storeInfo) {
        toreturn += `${key} -> ${storeInfo[key].price} (${storeInfo[key].town})\n`;
    }

    return toreturn;
}



console.log(solve(['Sofia City | Audi | 100000',
'Sofia City | BMW | 100000',
'Sofia City | Mitsubishi | 10000',
'Sofia City | Mercedes | 10000',
'Sofia City | NoOffenseToCarLovers | 0',
'Mexico City | Audi | 1000',
'Mexico City | BMW | 99999',
'New York City | Mitsubishi | 10000',
'New York City | Mitsubishi | 1000',
'Mexico City | Audi | 100000',
'Washington City | Mercedes | 1000'
]
));
