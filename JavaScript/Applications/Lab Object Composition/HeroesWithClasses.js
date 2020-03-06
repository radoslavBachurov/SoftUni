function solve() {
    let creator = { mage, fighter };

    function mage(inputName) {
        class Mage{
            constructor(inputName){
                this.name = inputName;
                this.mana = 100;
                this.health = 100;
            }
           
            cast(spellName){
                console.log(`${this.name} cast ${spellName}`)
                this.mana--;
            }
        }
        let newMage = new Mage(inputName);
        return newMage;
    }

    function fighter(inputName) {
        class Fighter{
            constructor(inputName){
                this.name = inputName;
                this.stamina = 100;
                this.health = 100;
            }
           
            fight(spellName){
                console.log(`${this.name} cast ${spellName}`)
                this.stamina--;
            }
        }
        let newFighter = new Fighter(inputName);
        return newFighter;
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
