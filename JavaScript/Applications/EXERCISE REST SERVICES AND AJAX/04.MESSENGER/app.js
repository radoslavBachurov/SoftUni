function attachEvents() {
    let name = document.getElementById('author');
    let message = document.getElementById('content');
    let sendButton = document.getElementById('submit');
    let refreshButton = document.getElementById('refresh');
    let textBox = document.getElementById(`messages`);
    let url = `https://rest-messanger.firebaseio.com/messanger.json`;

    sendButton.addEventListener('click', () => {
        let author = name.value;
        let content = message.value;

        if (name && content) {
            let newObj = { author, content };

            fetch(url, {
                method: 'POST',
                body: JSON.stringify(newObj)
            })
        }

        name.value = '';
        message.value = '';
        refreshTextBox();
    })

    refreshButton.addEventListener('click', refreshTextBox);

    function refreshTextBox() {
        textBox.value = '';
        fetch(`https://rest-messanger.firebaseio.com/messanger.json`)
            .then((info) => info.json())
            .then((data) => {
                let values = Object.values(data);
                values.forEach(element => {
                    textBox.value += `${element.author}: ${element.content}\n`
                });
            })
    }
}

attachEvents();