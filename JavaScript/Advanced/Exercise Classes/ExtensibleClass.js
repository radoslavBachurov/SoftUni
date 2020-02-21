class Extensible {

    constructor() {
        Extensible.prototype.id = Extensible.prototype.id == undefined ? 0 : Extensible.prototype.id + 1;
        this.id = Extensible.prototype.id;
    }

    extend(template) {

        for (let [key, value] of Object.entries(template)) {

            if (typeof (value) == 'function') {
                Extensible.prototype[key] = value;
            }
            else {
                this[key] = value;
            }
        }

    }
}


var template = {
    val1: 1
};
  
let obj1 = new Extensible();
obj1.extend(template)
console.log(obj1)
