class Hex {
    constructor(num) {
        this.number = num;
    }

    valueOf() {
        return this.number;
    }

    toString() {
        return ('0x' + (this.number.toString(16).toUpperCase()));
    }

    plus(number) {
        let toadd = 0;
        if (typeof (number) === 'number') {
            toadd = number;
        } else {
            toadd = number.valueOf();
        }

        let toReturn = new Hex(toadd + this.number);
        return toReturn;
    }

    minus({ number }) {
        let toadd = 0;
        if (typeof (number) === 'number') {
            toadd = number;
        } else {
            toadd = number.valueOf();
        }

        let toReturn = new Hex(this.number- toadd);
        return toReturn;
    }

    parse(string) {
        yourNumber = parseInt(Number(string), 16);
        return yourNumber;
    }
}

let FF = new Hex(255);
console.log(FF.toString());
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString()==='0xF');

