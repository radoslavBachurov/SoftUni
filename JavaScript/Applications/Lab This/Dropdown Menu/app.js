function solve() {
    let dropdown = document.getElementById('dropdown');
    let menu = document.getElementById('dropdown-ul');
    let box = document.getElementById('box');

    dropdown.addEventListener('click', () => {
        let menu = document.getElementById('dropdown-ul');

        if (menu.style.display == 'block') {
            menu.style.display = 'none';
            box.style.backgroundColor = 'black';
        }
        else {
            menu.style.display = 'block'
        }
    })

    menu.addEventListener('click', (ev) => {
        let color = ev.target.textContent;
        box.style.backgroundColor = color;
    })
}
