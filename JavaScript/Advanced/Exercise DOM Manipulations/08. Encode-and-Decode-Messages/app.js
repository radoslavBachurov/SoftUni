function encodeAndDecodeMessages() {
    let sendertext = document.getElementsByTagName('textarea')[0];
    let receiverText = document.getElementsByTagName('textarea')[1];
    let encode = document.getElementsByTagName('button')[0];
    let decode = document.getElementsByTagName('button')[1];

    encode.addEventListener('click', () => {
        let textInSymbols = sendertext.value.split('').map(x => x.charCodeAt(0) + 1).map(x => String.fromCharCode(x)).join('');
        sendertext.value = '';
        receiverText.value = textInSymbols;
    });

    decode.addEventListener('click', () => {
        let decodingText = receiverText.value.split('').map(x => x.charCodeAt(0) - 1).map(x => String.fromCharCode(x)).join('');
        receiverText.value = decodingText;
    })
}