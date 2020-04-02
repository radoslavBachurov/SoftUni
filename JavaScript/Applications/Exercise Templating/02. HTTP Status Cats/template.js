
(async () => {
    Handlebars.registerPartial('cat', await fetch('./singleCat.hbs').then((r) => r.text()));

    const template = Handlebars.compile(await fetch(`./catsTemplate.hbs`).then((x) => x.text()));

    const resultHTML = template({ cats });
    document.querySelector("section#allCats").innerHTML += resultHTML;

    let showBtns = document.querySelectorAll('button');
    showBtns.forEach(element => {
        element.addEventListener('click', () => {
            const parent = element.parentNode;
            const statusDiv = parent.querySelector('div.status');
            if (statusDiv.style.display == 'none') {
                element.textContent = 'Hide status code'
                statusDiv.style.display = 'block';
            }
            else {
                element.textContent = 'Show status code'
                statusDiv.style.display = 'none';
            }
        })
    });
})();