class Rat {
    unitedRats = [];
    constructor(name) {
        this.name = name;
    }

    toString() {
        return this.name + this.unitedRats.map(x => `\n##${x}`);
    }

    unite(maybeRat) {

        if (maybeRat instanceof Rat) {
            this.unitedRats.push(maybeRat);
        }
    }

    getRats() {
        return this.unitedRats;
    }
}

let firstRat = new Rat("Peter");
console.log(firstRat.toString()); // Peter

console.log(firstRat.getRats()); // []

firstRat.unite(new Rat("George"));
firstRat.unite(new Rat("Alex"));
console.log(firstRat.getRats());
// [ Rat { name: 'George', unitedRats: [] },
//  Rat { name: 'Alex', unitedRats: [] } ]

console.log(firstRat.toString());
// Peter
// ##George
// ##Alex
