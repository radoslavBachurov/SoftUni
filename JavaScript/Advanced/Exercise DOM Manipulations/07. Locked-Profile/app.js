function lockedProfile() {
    let mainSection = document.getElementById('main');

    mainSection.addEventListener('click', (ev) => {

        let section = ev.target.parentElement;
        let openSystem = section.getElementsByTagName('input')[1].checked;
        let hiddenInfo = section.getElementsByTagName('div')[0];
        let button = section.getElementsByTagName('button')[0];

        if (ev.target.type === 'radio') {
            ev.target.checked = true;

        }
        else if (ev.target.textContent === 'Show more' && openSystem) {
            hiddenInfo.style.display = 'block';
            button.textContent = 'Hide it';
        }
        else if (ev.target.textContent === 'Hide it' && openSystem) {
            hiddenInfo.style.display = 'none';
            button.textContent = 'Show more';
        }
    })
}