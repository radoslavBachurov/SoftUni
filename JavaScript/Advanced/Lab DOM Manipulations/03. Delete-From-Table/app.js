function deleteByEmail() {
    let input = document.getElementsByTagName('input')[0];
    let emails = document.getElementsByTagName('td');
    let message = document.getElementById('result');

    let notFounded = true;
    for (let index = 0; index < emails.length; index++) {

        if (input.value.trim() == emails[index].textContent) {
            let toremove = emails[index].parentElement;
            toremove.remove();
            message.textContent = 'deleted';
            notFounded = false;
            break;
        }
    }

    if (notFounded) {
        message.textContent = "Not found.";
    }

}