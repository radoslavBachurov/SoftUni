(async () => {

    const template = Handlebars.compile(await fetch(`./allMonkeys.hbs`).then((x) => x.text()));

    const resultHTML = template({ monkeys });
    document.querySelector(".monkeys").innerHTML += resultHTML;

    let showBtns = document.querySelectorAll('button');
    showBtns.forEach(element => {
        element.addEventListener('click', () => {
            const parent = element.parentNode;
            const statusDiv = parent.getElementsByTagName('p')[0];
            if (statusDiv.style.display == 'none') {
                element.textContent = 'Hide Info'
                statusDiv.style.display = 'block';
            }
            else {
                element.textContent = 'Info'
                statusDiv.style.display = 'none';
            }
        })
    });
})();