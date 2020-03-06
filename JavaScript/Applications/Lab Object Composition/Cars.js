function solve(input) {

    class Car {
        constructor(name) {
            this.inheritedCars = [];
            this.properties = {};
            this.name = name;
            this.mainCar = '';
        }

        addCarProperties(key, value) {
            this.properties[key] = value;
        }

        getProperties() {
            let props = Object.entries(this.properties);
            return props;
        }

        addInheritedCar(newCar) {
            this.inheritedCars.push(newCar);
        }
    }

    class CarCatalogue {
        constructor() {
            this.allCars = [];
        }

        addNewCar(newCar) {
            this.allCars.push(newCar);
        }

        checkForCar(name) {
            let result = this.allCars.some(x => x.name == name);
            return result;
        }

        getCar(name) {
            let car = this.allCars.find(x => x.name == name);
            return car;
        }
    }

    class CommandInterpreter {
        constructor() {
            this.commandManager = new CommandManager;
        }

        processingCommand(input) {
            let inputArr = input.split(' ').filter(x => x !== ' ');

            if (inputArr[0] == `set`) {
                this.commandManager.setCarProperties(inputArr[1], inputArr[2], inputArr[3]);
            }
            else if (inputArr[0] == 'create') {
                this.commandManager.createCar(inputArr[3]);

                if (inputArr[2] == 'inherit') {
                    this.commandManager.inheritCar(inputArr[1], inputArr[3]);
                }
            }
            else {
                this.commandManager.printCar(inputArr[1]);
            }
        }
    }

    class CommandManager {
        constructor() {
            this.CarCatalogue = new CarCatalogue();
        }

        createCar(name) {
            if (!this.CarCatalogue.checkForCar(name)) {
                let newCar = new Car(name);
                this.CarCatalogue.addNewCar(newCar);
            }
        }

        inheritCar(name, main) {

            let newCar = new Car(name);
            newCar.mainCar = main;
            let mainCar = this.CarCatalogue.getCar(main);

            mainCar.addInheritedCar(newCar);
            this.CarCatalogue.addNewCar(newCar);

        }

        setCarProperties(name, key, value) {
            if (this.CarCatalogue.checkForCar(name)) {
                let mainCar = this.CarCatalogue.getCar(name);
                mainCar.addCarProperties(key, value);
            }
        }

        printCar(name) {
            if (this.CarCatalogue.checkForCar(name)) {
                let car = this.CarCatalogue.getCar(name);
                let propsCurrArr = car.getProperties().map(x => `${x[0]}:${x[1]}`);
                let propsMainCar = car.mainCar !== '' ? getAllProps(car.mainCar, this.CarCatalogue).map(x => `${x[0]}:${x[1]}`) : false;

                if (!!propsMainCar) {
                    propsCurrArr = propsCurrArr.concat(propsMainCar);
                }

                console.log(propsCurrArr.join(', '));
            }

            function getAllProps(mainCar, catalogue) {
                let car = catalogue.getCar(mainCar);
                let propsMainCar = car.getProperties()
                if (car.mainCar !== '') {
                    propsMainCar = propsMainCar.concat(getAllProps(car.mainCar, catalogue));
                }
                return propsMainCar;
            }
        }
    }

    let myCommandInterpreter = new CommandInterpreter();
    input.forEach(element => {
        myCommandInterpreter.processingCommand(element);
    });
}

solve(['create pesho', 'create gosho inherit pesho', 'create stamat inherit gosho', 'set pesho rank number1', 'set gosho nick goshko', 'print stamat'])
