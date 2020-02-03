function solution() {

    let robot = (function () {
        let protein = 0;
        let carbohydrate = 0;
        let fat = 0;
        let flavour = 0;

        function report() {
            return `protein=${robot.protein} carbohydrate=${robot.carbohydrate} fat=${robot.fat} flavour=${robot.flavour}`;
        }
        function restock(ingridient, value) {
            robot[ingridient] += value;
        }

        function prepareMeal(meal) {
            let obj = {};
            switch (meal) {

                case 'apple':
                    obj = { 'carbohydrate': 1, 'flavour': 2 }
                    break;
                case 'lemonade':
                    obj = { 'carbohydrate': 10, 'flavour': 20 }
                    break;
                case 'burger':
                    obj = { 'carbohydrate': 5, 'fat': 7, 'flavour': 3 }
                    break;
                case 'eggs':
                    obj = { 'protein': 5, 'fat': 1, 'flavour': 1 }
                    break;
                case 'turkey':
                    obj = { 'protein': 10, 'carbohydrate': 10, 'fat': 10, 'flavour': 10 }
                    break;

                default:
                    break;
            }

            for (const ingridient in obj) {
                if (obj[ingridient] > robot[ingridient]) {
                    return [false, ingridient];
                }
            }
            for (const ingridient in obj) {
                robot[ingridient] -= obj[ingridient];
            }
            return [true];
        }

        return {
            prepareMeal,
            restock,
            report, protein, carbohydrate, fat, flavour
            
        }

    })()

    function manageCommand(input) {
        let inputArr = input.split(' ').map(x => x.trim());

        let command = inputArr[0];

        if (command === 'report') {
            return robot.report();
        }
        else if (command === 'prepare') {
            let meal = inputArr[1];
            let count = Number(inputArr[2]);
            let result = true;

            for (let index = 0; index < count; index++) {
                result = robot.prepareMeal(meal);
                if (result[0] == false) {
                    return `Error: not enough ${result[1]} in stock`
                }
            }
            return 'Success';
        }
        else {
            let ingridient = inputArr[1];
            let quantity = Number(inputArr[2]);
            robot.restock(ingridient, quantity);
            return 'Success';
        }

    }

    return manageCommand;

}

let manager = solution();
console.log(manager('restock carbohydrate 10'));
console.log(manager('restock flavour 10'));
console.log(manager('prepare apple 1'));
console.log(manager('restock fat 10'));
console.log(manager('prepare burger 1'));
console.log(manager('report'));



