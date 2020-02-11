function addItem() {
    let items = document.getElementById('items');
    let input = document.getElementById('newItemText');

    let toAdd = document.createElement('li');
    toAdd.appendChild(document.createTextNode(input.value));
    items.appendChild(toAdd);
    input.value = '';
}