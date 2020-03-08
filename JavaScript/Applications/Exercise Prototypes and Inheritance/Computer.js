function solve() {


    class Product {
        constructor(manufacturer) {
            if (new.target === Product) {
                throw new Error('Abstract class cannot be instantiated directly');
            }
            this.manufacturer = manufacturer;
        }
    }

    class Keyboard extends Product {
        constructor(manufacturer, responseTime) {
            super(manufacturer);
            this.responseTime = responseTime;
        }
    }

    class Monitor extends Product {
        constructor(manufacturer, width, height) {
            super(manufacturer);
            this.width = width;
            this.height = height;
        }
    }

    class Battery extends Product {
        constructor(manufacturer, expectedLife) {
            super(manufacturer);
            this.expectedLife = expectedLife;
        }
    }

    class Computer extends Product {
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace) {
            if (new.target === Computer) {
                throw new Error('Abstract class cannot be instantiated directly');
            }
            super(manufacturer);
            this.ram = ram;
            this.hardDiskSpace = hardDiskSpace;
            this.processorSpeed = processorSpeed;
        }
    }


    class Laptop extends Computer {
        _battery;
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace, weight, color, battery) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);
            this.weight = weight;
            this.color = color;
            this.battery = battery;
        }

        get battery() {
            return this._battery;
        }

        set battery(value) {
            if (value instanceof Battery) {
                this._battery = value;
            }
            else{
                throw new TypeError
            }
        }
    }

    class Desktop extends Computer {
        _keyboard;
        _monitor;
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace, keyboard, monitor) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);
            this.keyboard = keyboard;
            this.monitor = monitor;
        }

        get keyboard() {
            return this._keyboard;
        }

        set keyboard(value) {
            if (value instanceof Keyboard) {
                this._keyboard = value;
            }
            else{
                throw new TypeError
            }
        }

        get monitor() {
            return this._monitor;
        }

        set monitor(value) {
            if (value instanceof Monitor) {
                this._monitor = value;
            }
            else{
                throw new TypeError
            }
        }
    }

    return {
        Keyboard, Monitor, Battery, Computer, Laptop, Desktop
    }
}
