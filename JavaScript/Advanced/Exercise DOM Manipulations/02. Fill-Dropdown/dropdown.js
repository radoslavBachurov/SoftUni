function addItem() {
    let textBox = document.getElementById('newItemText');
    let valueBox = document.getElementById('newItemValue');
    let toAppend = document.getElementById('menu');

    let newElement = document.createElement('option');
    newElement.appendChild(document.createTextNode(textBox.value+valueBox.value));
    toAppend.appendChild(newElement);

    textBox.value = '';
    valueBox.value = '';
}