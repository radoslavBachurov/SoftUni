function validate() {
    let input = document.getElementById('email');
    //input.className = input.className + " error";

    input.addEventListener('change', () => {
        let inputValue = input.value;
        let result = inputValue.match(/^[a-z]+[@]{1}[a-z]+[.]{1}[a-z]+$/g);

        if (result === null) {
            input.className = input.className + " error";
            console.log('enter')
        }
        else{
            input.className = input.className.replace(" error", "");
            console.log('exit')
        }
    })
}