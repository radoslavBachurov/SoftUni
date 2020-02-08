function solve() {

    let addButton = document.getElementsByTagName('button')[0];
    let alphabet = 'abcdefghijklmnopqrstuvwxyz'.split('');

    addButton.addEventListener('click', () => {
        let input = document.getElementsByTagName('input')[0];
        let database = document.getElementsByTagName('li');

        if (input.value == '') {
            return;
        }

        let letter = input.value[0];
        let letterIndex = alphabet.indexOf(letter.toLowerCase());
        let nametoAdd = input.value.charAt(0).toUpperCase() + input.value.slice(1).toLowerCase();

        if (database[letterIndex].innerHTML != '') {
            database[letterIndex].innerHTML += `, ${nametoAdd}`;
        }
        else {
            database[letterIndex].innerHTML = nametoAdd;
        }

        input.value = '';
    })
}