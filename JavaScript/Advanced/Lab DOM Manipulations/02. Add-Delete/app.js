function addItem() {
    let items = document.getElementById('items');
    let input = document.getElementById('newText');

    let toAdd = document.createElement('li');
    toAdd.appendChild(document.createTextNode(`${input.value} `));

    var btn = document.createElement("button");
    btn.innerHTML = "[delete]";
    
    btn.addEventListener('click', (ev) => {
       let toRemove = btn.parentNode;
       toRemove.remove();
    })

    toAdd.appendChild(btn);
    items.appendChild(toAdd);
    input.value = '';
} 