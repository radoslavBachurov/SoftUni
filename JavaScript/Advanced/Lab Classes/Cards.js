let result = (function () {
    let Suits = {
        'SPADES': '♠',
        'HEARTS': '♥',
        'DIAMONDS': '♦',
        'CLUBS': '♣'
    }

    let validFaces = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];

    class Card {
        constructor(face, suit) {
            this.face = face;
            this.suit = suit;
        }

        get suit() {
            return this.innerSuit;
        }

        set suit(input) {
            if (Object.values(Suits).includes(input)) {
                this.innerSuit = input;
            }
            else {
                throw new Error;

            }

        }

        get face() {
            return this.innerFace;
        }

        set face(input) {
            if (validFaces.includes(input)) {
                this.innerFace = input;
            }
            else {
                throw new Error;
            }
        }
    }
    return {
        'Suits': Suits,
        'Card': Card
    }

})();

let Card = result.Card;
let Suits = result.Suits;

let card = new Card(`Q`,Suits.CLUBS);
card.face = `A`;
card.suit = Suits.HEARTS;
console.log(card)

let card2 = new Card(`1`,Suits.CLUBS);