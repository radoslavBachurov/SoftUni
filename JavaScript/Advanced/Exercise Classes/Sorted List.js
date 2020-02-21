class List {

    constructor() {
        this.collection = [];
        this.size = 0;
    }

    add(elemenent) {
        this.collection.push(elemenent);
        this.collection.sort((a, b) => a - b);
        this.size++;
    }

    remove(index) {
        if (index >= 0 && index < this.collection.length) {
            this.collection.splice(index, 1);
            this.collection.sort((a, b) => a - b);
            this.size--;
        }

    }

    get(index) {
        if (index >= 0 && index < this.collection.length) {
            return this.collection[index];
        }
    }

}

let list = new List();
list.add(7);
list.add(42);
list.add(1);


console.log(list.size);
