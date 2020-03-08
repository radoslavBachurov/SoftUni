function solve() {
    class Balloon {
        constructor(color, gasWeight) {
            this.color = color;
            this.gasWeight = gasWeight;
        }
    }

    class PartyBalloon extends Balloon {
        _ribbon;
        constructor(color, gasWeight, ribbonColor, ribbonLength) {
            super(color, gasWeight);
            this.ribbonColor = ribbonColor;
            this.ribbonLength = ribbonLength;
            this.ribbon = { 'color': ribbonColor, 'length': ribbonLength };
        }

        get ribbon() {
            return this._ribbon;
        }

        set ribbon(input) {
            this._ribbon = input;
        }
    }

    class BirthdayBalloon extends PartyBalloon {
        _text;
        constructor(color, gasWeight, ribbonColor, ribbonLength, text) {
            super(color, gasWeight, ribbonColor, ribbonLength);
            this.text = text;
        }

        get text() {
            return this._text;
        }

        set text(input) {
            this._text = input;
        }
    }

    return {
        Balloon, PartyBalloon, BirthdayBalloon
    }
}