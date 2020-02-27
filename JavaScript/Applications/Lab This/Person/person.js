class Person {
    _fn;
    _ln;
    constructor(fn, ln) {
        this.firstName = fn;
        this.lastName = ln;
    }

    get firstName() {
        return this._fn;
    }

    get lastName() {
        return this._ln;
    }

    get fullName() {
        return `${this._fn} ${this._ln}`;
    }

    set firstName(value) {
        this._fn = value;
    }

    set lastName(value) {
        this._ln = value;
    }

    set fullName(value) {
        let twoNames = value.split(' ').filter(x => x != ' ');

        if (twoNames[0] !== undefined && twoNames[1] !== undefined) {
            this._fn = twoNames[0];
            this._ln = twoNames[1];
        }
    }
}

let person = new Person("Albert", "Simpson");
console.log(person.fullName);//Albert Simpson
person.firstName = "Simon";
console.log(person.fullName);//Simon Simpson
person.fullName = "Peter";
console.log(person.firstName) // Simon
console.log(person.lastName) // Simpson
