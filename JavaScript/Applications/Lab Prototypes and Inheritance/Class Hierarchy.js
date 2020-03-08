function hierarchy() {

    class Figure {
        constructor(input) {
            this.type = input ? input : 'cm';
        }

        changeUnits(input) {
            this.type = input;
        }

        calculate(input) {
            if (this.type == 'mm') {
                return input * 10;
            }
            else if (this.type == 'm') {
                return input / 100;
            }
            return input;
        }
    }

    class Circle extends Figure {
        constructor(radius, input) {
            super(input);
            this.radius = this.calculate(radius);
        }


        changeUnits(input) {
            if (this.type == 'mm') {
                this.radius = this.radius / 10;
            }
            else if (this.type == 'm') {
                this.radius = this.radius * 100;
            }
            this.type = input;
            this.radius = this.calculate(this.radius);
        }

        get area() {
            return Math.PI * this.radius * this.radius;
        }

        toString() {
            return `Figures units: ${this.type} Area: ${this.area} - radius: ${this.radius}`;
        }

    }

    class Rectangle extends Figure {
        constructor(width, height, input) {
            super(input);
            this.width = this.calculate(width);
            this.height = this.calculate(height);
        }



        changeUnits(input) {
            if (this.type == 'mm') {
                this.width = this.width / 10;
                this.height = this.height / 10;
            }
            else if (this.type == 'm') {
                this.width = this.width * 100;
                this.height = this.height * 100;
            }
            this.type = input;
            this.width = this.calculate(this.width);
            this.height = this.calculate(this.height);
        }

        get area() {

            return this.width * this.height;

        }

        toString() {
            return `Figures units: ${this.type} Area: ${this.area} - width: ${this.width}, height: ${this.height}`;
        }

    }

    return {
        Figure,
        Circle,
        Rectangle
    }
}


let c = new Circle(5);
console.log(c.area); // 78.53981633974483
console.log(c.toString()); // Figures units: cm Area: 78.53981633974483 - radius: 5

let r = new Rectangle(3, 4, 'mm');
console.log(r.area); // 1200 
console.log(r.toString()); //Figures units: mm Area: 1200 - width: 30, height: 40

r.changeUnits('cm');
console.log(r.area); // 12
console.log(r.toString()); // Figures units: cm Area: 12 - width: 3, height: 4

c.changeUnits('mm');
console.log(c.area); // 7853.981633974483
console.log(c.toString()) // Figures units: mm Area: 7853.981633974483 - radius: 50

