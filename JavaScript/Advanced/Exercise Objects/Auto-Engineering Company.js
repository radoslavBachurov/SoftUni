function solve(input) {
    const inputArr = input;
    const carList = {};

    for (let index = 0; index < inputArr.length; index++) {
        let currBrandArr = inputArr[index].split(' | ').filter(x => x != '');
        let brand = currBrandArr[0];
        let model = currBrandArr[1];
        let count = +currBrandArr[2];

        let newCar = {};
        newCar[model] = count;

        if (carList[brand] == undefined) {
            carList[brand] = newCar;
        }
        else {
            if (carList[brand][model] == undefined){
                carList[brand][model] = count
            }
            else{
                carList[brand][model] += count;
            }
        }
    }

    for (const key in carList) {
        console.log(`${key}`);
        for (const secKey in carList[key]) {
            console.log(`###${secKey} -> ${carList[key][secKey]}`)
        }

    }
}

solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']
);