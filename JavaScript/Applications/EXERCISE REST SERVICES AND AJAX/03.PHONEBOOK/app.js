function attachEvents() {
    let loadBtn = document.getElementById('btnLoad');
    let phoneBook = document.getElementById('phonebook');
    let crtButton = document.getElementById('btnCreate');
    let getURL = `https://phonebook-nakov.firebaseio.com/phonebook.json`;

    loadBtn.addEventListener('click', loadAction)
    crtButton.addEventListener('click', crtAction)

    function loadAction() {
        phoneBook.innerHTML = '';

        fetch(getURL)
            .then((info) => info.json())
            .then((data) => {
                for (const key in data) {
                    let name = data[key].person;
                    let phone = data[key].phone;

                    if (!!name || !!phone) {
                        let newLi = document.createElement('li');
                        var btn = document.createElement("BUTTON");
                        btn.innerHTML = "Delete";
                        btn.addEventListener('click', () => {
                            fetch(`https://phonebook-nakov.firebaseio.com/phonebook/${key}.json`, {
                                method: 'DELETE'
                            })
                                .then(() => { loadAction() });
                        });

                        newLi.textContent = `${name}: ${phone}`;
                        newLi.appendChild(btn);

                        phoneBook.appendChild(newLi);
                    }
                }
            })
    }

    function crtAction() {
        let person = document.getElementById('person').value;
        let phone = document.getElementById('phone').value;
        let uniqueId = makeid(20);

        let newObj = {};
        newObj[uniqueId] = { person, phone };

        fetch(getURL, {
            method: 'PATCH',
            body: JSON.stringify(newObj)
        })
            .then(() => {
                loadAction();
                document.getElementById('person').value = '';
                document.getElementById('phone').value = '';
            })
    }

    function makeid(length) {
        var result = '';
        var characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
        var charactersLength = characters.length;
        for (var i = 0; i < length; i++) {
            result += characters.charAt(Math.floor(Math.random() * charactersLength));
        }
        return result;
    }
}



attachEvents();