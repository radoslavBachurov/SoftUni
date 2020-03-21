function attachEvents() {
    let cathesBox = document.getElementById('catches');
    let loadBtn = document.querySelector("body > aside > button");
    let addBtn = document.querySelector("#addForm > button");

    let itm = document.querySelector("#catches > div");
    let blankCatch = itm.cloneNode(true);

    addBtn.addEventListener('click', addAction)
    loadBtn.addEventListener('click', loadAction);

    async function loadAction() {
        cathesBox.innerHTML = '';

        try {
            let url = `https://fisher-game.firebaseio.com/catches.json`;
            let allCatches = await fetch(url);
            let responce = await allCatches.json();

            for (const key in responce) {
                let newEl = createElement(responce[key].angler, responce[key].weight, responce[key].species,
                    responce[key].location, responce[key].bait, responce[key].captureTime, key);
                cathesBox.appendChild(newEl);
            }

        } catch (error) {
            console.error(error);
        }
    }

    async function addAction() {
        let newObj = {
            "angler": document.querySelector("#addForm > input.angler").value,
            "weight": document.querySelector("#addForm > input.weight").value,
            "species": document.querySelector("#addForm > input.species").value,
            "location": document.querySelector("#addForm > input.location").value,
            "bait": document.querySelector("#addForm > input.bait").value,
            "captureTime": document.querySelector("#addForm > input.captureTime").value
        };

        try {
            let url = `https://fisher-game.firebaseio.com/catches.json`;

            await fetch(url, {
                method: 'POST',
                body: JSON.stringify(newObj)
            })
        } catch (error) {
            console.error(error);
        }

        document.querySelector("#addForm > input.angler").value = '';
        document.querySelector("#addForm > input.weight").value = '';
        document.querySelector("#addForm > input.species").value = '';
        document.querySelector("#addForm > input.location").value = '';
        document.querySelector("#addForm > input.bait").value = '';
        document.querySelector("#addForm > input.captureTime").value = '';

    }

    function createElement(anglerInput, weight, species, location, bate, captureTime, key) {
        let newCatch = blankCatch.cloneNode(true);
        newCatch.querySelector(".angler").setAttribute("value", anglerInput);
        newCatch.querySelector(".weight").setAttribute("value", weight);
        newCatch.querySelector(".species").setAttribute("value", species);
        newCatch.querySelector(".location").setAttribute("value", location);
        newCatch.querySelector(".bait").setAttribute("value", bate);
        newCatch.querySelector(".captureTime").setAttribute("value", captureTime);
        newCatch.setAttribute('data-id', key);

        let uptButton = newCatch.querySelector('.update');
        let dltButton = newCatch.querySelector('.delete');

        uptButton.addEventListener('click', updAction);
        dltButton.addEventListener('click', dltAction);

        return newCatch;
    }

    async function updAction(ev) {
        let currCatch = ev.target.closest("div");
        let catchObj = {
            'angler': currCatch.querySelector(".angler").value,
            'weight': currCatch.querySelector(".weight").value,
            'species': currCatch.querySelector(".species").value,
            'location': currCatch.querySelector(".location").value,
            'bait': currCatch.querySelector(".bait").value,
            'captureTime': currCatch.querySelector(".captureTime").value
        };
        let id = currCatch.getAttribute('data-id');
        let url = `https://fisher-game.firebaseio.com/catches/${id}.json`;
        try {
            await fetch(url, {
                method: 'PUT',
                body: JSON.stringify(catchObj)
            })
        } catch (error) {
            console.error(error);
        }

    }

    async function dltAction(ev) {
        let currCatch = ev.target.closest("div");
        let id = currCatch.getAttribute('data-id');
        let url = `https://fisher-game.firebaseio.com/catches/${id}.json`;

        try {
            await fetch(url, {
                method: 'DELETE',
            })
        } catch (error) {
            console.error(error);
        }

        loadAction();
    }
}

attachEvents();

