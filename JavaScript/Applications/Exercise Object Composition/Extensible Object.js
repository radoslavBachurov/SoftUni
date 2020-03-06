function createObj() {
    let myObj = {
        'extend': function (template) {
            for (const key in template) {
                if (typeof (template[key]) == 'function') {
                    myObj.__proto__[key] = template[key];

                }
                else {
                    myObj[key] = template[key];
                }
            }
        }
    }

    return myObj;
}

var template = {
    name: '',
    setName: function (newValue) {
        this.name = newValue;
    },
    getName: function () {
        return this.name;
    }
};

var testObject = createObj();
testObject.extend(template);
testObject.setName('new name');
