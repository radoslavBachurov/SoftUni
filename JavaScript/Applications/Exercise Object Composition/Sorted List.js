function sortedList() {
    let myList = {

        'innerList': [],

        'add': function add(el) {
            myList.innerList.push(el);
            myList.innerList.sort((a, b) => a - b);
            myList.size++;
        },

        'remove': function remove(index) {
            if (index < 0 || index >= myList.innerList.length) {
                throw new Error('index is outside the boundaries of an array');
            }
            let element = myList.innerList.splice(index, 1);
            myList.innerList.sort((a, b) => a - b);
            myList.size--;
            return element[0];
        },

        'get': function get(index) {
            if (index < 0 || index >= myList.innerList.length) {
                throw new Error('index is outside the boundaries of an array');
            }
            let element = myList.innerList[index]

            return element;
        },

        'size': 0
    }

    return myList;
}


var expectedArray = [];
for (let i = 0; i < 20; i++) {
    expectedArray.push(Math.floor(Math.random() * 200) - 100);
}
console.log(expectedArray)