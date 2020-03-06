function solve() {
    let creator = {
        mage: function createmage(name) {
            let newmag = new mage(name)
            return newmag
        },
        fighter: function createfighter(name) {
            let newfighter = new fighter(name)
            return newfighter
        }
    }

    function mage(inputName) {
        this.name = inputName;
        this.mana = 100;
        this.health = 100;
        this.cast = (spellName) => {
            console.log(`${this.name} cast ${spellName}`)
            this.mana--;
        }

    }

    function fighter(inputName) {
        this.name = inputName;
        this.stamina = 100;
        this.health = 100;
        this.fight = () => {
            console.log(`${this.name} slashes at the foe!`)
            this.stamina--;
        }

    }

    return creator;
}

let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball")
scorcher.cast("thunder")
scorcher.cast("light")

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight()

console.log(scorcher2.stamina);
console.log(scorcher.mana);