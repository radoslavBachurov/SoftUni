class Circle {
    constructor(rad) {
        this.radius = rad;
    }

    get diameter() {
        return this.innerrRadius * 2;
    }

    set diameter(input) {
        this.innerrRadius = input / 2;
    }

    set radius(rad) {

        this.innerrRadius = rad;
    }

    get radius() {
        return this.innerrRadius;
    }

    get area() {

        return Math.PI*(Math.pow(this.innerrRadius, 2));
    };
}

let c = new Circle(2);
console.log(`Radius: ${c.radius}`);
console.log(`Diameter: ${c.diameter}`);
console.log(`Area: ${c.area}`);
c.diameter = 1.6;
console.log(`Radius: ${c.radius}`);
console.log(`Diameter: ${c.diameter}`);
console.log(`Area: ${c.area}`);
