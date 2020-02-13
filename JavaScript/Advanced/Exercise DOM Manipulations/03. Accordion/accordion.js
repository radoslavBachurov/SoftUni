function toggle() {
    let button = document.getElementsByTagName('span')[0];
    let hidden = document.getElementById('extra');

    if (button.textContent === 'More') {
        button.textContent = 'Less';
        
        hidden.style.display = "block";
    }
    else {
        button.textContent = 'More'
       
        hidden.style.display = "none";
    }

}