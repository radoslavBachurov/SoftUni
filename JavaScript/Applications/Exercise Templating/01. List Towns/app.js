let loadBtn = document.getElementById("btnLoadTowns");
let textBox = document.getElementById('root');

loadBtn.addEventListener('click', () => {

    Promise.all([
        fetch('./template.hbs').then((responce) => responce.text()),
        fetch(`https://restcountries.eu/rest/v2/all`).then((responce) => responce.json())
    ])
        .then(([templateHBS, countries]) => {
            let template = Handlebars.compile(templateHBS);
            let result = template({ countries });
            textBox.innerHTML = result;
        })
})