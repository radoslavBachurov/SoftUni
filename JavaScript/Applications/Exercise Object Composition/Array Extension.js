(function solve() {
    Array.prototype.last = function () {
        if (this.length === 0) {

            throw new Error('No elements in array');
        }
        let num = this;
        return this[this.length - 1];
    }

    Array.prototype.skip = function (n) {
        let toReturn = [];

        if (n < 0 || n >= this.length) {
            throw new Error('Index is outside boundaries of the array')
        }

        for (let index = n; index < this.length; index++) {
            toReturn.push(this[index]);
        }

        return toReturn;
    }

    Array.prototype.take = function (n) {
        let toReturn = [];

        if (n < 0 || n >= this.length) {
            throw new Error('Index is outside boundaries of the array')
        }

        for (let index = 0; index < n; index++) {
            toReturn.push(this[index]);
        }

        return toReturn;
    }

    Array.prototype.sum = function () {
        let toReturn = 0;

        for (let index = 0; index < this.length; index++) {
            toReturn += this[index];
        }

        return toReturn;
    }

    Array.prototype.average = function () {
        let toReturn = 0;

        for (let index = 0; index < this.length; index++) {
            toReturn += this[index];
        }

        return (toReturn / this.length);
    }
}())

let newArr = [1, 2, 3];
console.log(newArr.last());