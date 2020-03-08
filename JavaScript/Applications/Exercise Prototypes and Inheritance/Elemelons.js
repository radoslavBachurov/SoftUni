function solve() {
    class Melon {
        _elementIndex;
        constructor(weight, melonSort) {
            if (new.target === Melon) {
                throw new Error('Abstract class cannot be instantiated directly');
            }
           // this.element = '';
            this.weight = weight;
            this.melonSort = melonSort;
            this.elementIndex = this.weight * this.melonSort.length;
        }

        get elementIndex() {
            return this._elementIndex;
        }

        set elementIndex(value) {
            this._elementIndex = value;
        }

        toString() {
            let toReturn = '';

            toReturn += `Element: ${this.element}\n`;
            toReturn += `Sort: ${this.melonSort}\n`;
            toReturn += `Element Index: ${this.elementIndex}`;

            return toReturn;
        }

    }

    class Watermelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.element = 'Water';
        }
    }

    class Firemelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.element = 'Fire';
        }
    }

    class Airmelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.element = 'Air';
        }
    }

    class Earthmelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.element = 'Earth';
        }
    }

    class Melolemonmelon extends Airmelon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.morphs = ['Fire', 'Earth', 'Air', 'Water'];
            this.element = 'Water';
        }

        morph() {
            let currSort = this.morphs.shift();
            this.element = currSort;
            this.morphs.push(currSort);
        }
    }

    return {
        Melon, Melolemonmelon, Firemelon, Watermelon, Earthmelon, Airmelon
    }
}
