class Stringer {

    constructor(str, lenght) {
        this.innerString = str;
        this.innerLength = lenght;
    }

    increase(length) {
        this.innerLength += length;
    }

    decrease(length) {
        this.innerLength -= length;
        if (this.innerLength < 0) {
            this.innerLength = 0;
        }
    }

    toString() {
      
        if (this.innerLength == 0) {
            return '...';
        }
        else if (this.innerLength >= this.innerString.length) {
            return this.innerString;
        }
        else {
            let countLetters = this.innerString.length - this.innerLength;
            let toReturn = this.innerString.substring(0, countLetters);
            return toReturn + '...';
        }

    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4);
console.log(test.toString()); // Test
