function solution() {
    let addButton = document.getElementsByTagName('button')[0];
    let inputText = document.querySelector("body > div > section:nth-child(1) > div > input[type=text]");
    let listOfGifts = document.querySelector("body > div > section:nth-child(2) > ul");
    let listOfSendedGifts = document.querySelector("body > div > section:nth-child(3) > ul");
    let listOfDisGifts = document.querySelector("body > div > section:nth-child(4) > ul");

    addButton.addEventListener('click', () => {
        let text = inputText.value;

        let new_li = document.createElement('LI');
        new_li.className = 'gift';
        var t = document.createTextNode(text);

        var sendButton = document.createElement("BUTTON");
        sendButton.id = 'sendButton';
        sendButton.textContent = 'Send'
        addListenerToSend(sendButton, text);

        var disButton = document.createElement("BUTTON");
        disButton.id = 'discardButton';
        disButton.textContent = 'Discard';
        addListenerToDis(disButton,text);

        new_li.appendChild(t);
        new_li.appendChild(sendButton);
        new_li.appendChild(disButton);
        listOfGifts.appendChild(new_li);

        inputText.value = '';
        sortList(listOfGifts);
    })

    function sortList(ul) {

        Array.from(ul.getElementsByTagName("LI"))
            .sort((a, b) => a.textContent.localeCompare(b.textContent))
            .forEach(li => ul.appendChild(li));
    }

    function addListenerToSend(sendButton, text) {
        sendButton.addEventListener('click', () => {
            let new_li = document.createElement('LI');
            new_li.className = 'gift';
            var t = document.createTextNode(text);
            new_li.appendChild(t);

            listOfSendedGifts.appendChild(new_li);

            let toRemove = sendButton.parentElement;
            listOfGifts.removeChild(toRemove); 
        })
    }

    function addListenerToDis(sendButton, text) {
        sendButton.addEventListener('click', () => {
            let new_li = document.createElement('LI');
            new_li.className = 'gift';
            var t = document.createTextNode(text);
            new_li.appendChild(t);

            listOfDisGifts.appendChild(new_li);

            let toRemove = sendButton.parentElement;
            listOfGifts.removeChild(toRemove); 
        })
    }

}