function notify(message) {
    let text = message;
    let hiddenPlace = document.getElementById('notification');

    hiddenPlace.textContent = text;
    hiddenPlace.style.display = 'block';

    setTimeout(hide, 2000);

    function hide(){
        hiddenPlace.style.display = 'none';
    }
}

