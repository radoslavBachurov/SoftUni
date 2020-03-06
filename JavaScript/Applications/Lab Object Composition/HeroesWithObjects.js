function solve() {

    function mage(inputName) {
        let newMage = {
            name: inputName,
            mana: 100,
            health: 100,
            cast: (spellName) => {
                console.log(`${newMage.name} cast ${spellName}`)
                newMage.mana--;
            }
        };

        return newMage;
    }

    function fighter(inputName) {
        let newFighter = {
            name: inputName,
            stamina: 100,
            health: 100,
            fight: () => {
                console.log(`${newFighter.name} slashes at the foe!`)
                newFighter.stamina--;
            }
        };
        return newFighter;
    }

    let creator = { mage,fighter};

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
