function solve(input) {
    const inputArr = input;
    const allProducts = [];
    for (let index = 0; index < inputArr.length; index++) {
        let currProduct = inputArr[index].split(' : ').filter(x => x != '');
        const currProductArr = [];
        currProductArr.push(currProduct[0], +currProduct[1]);
        allProducts.push(currProductArr);
    }

    allProducts.sort(function (a, b) {
        if (a[0] < b[0]) { return -1; }
        if (a[0] > b[0]) { return 1; }
        return 0;
    });

    let toReturn = '';
    let productLetter = '';
    for (let index = 0; index < allProducts.length; index++) {

        if (index == 0) {
            productLetter = allProducts[0][0][0];
            toReturn += `${productLetter}\n`
        }
        else if (allProducts[index][0][0] != productLetter) {
            productLetter = allProducts[index][0][0];
            toReturn += `${productLetter}\n`
        }

        toReturn += `  ${allProducts[index][0]}: ${allProducts[index][1]}\n`
    }

    return toReturn;
}

console.log(solve(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']

));