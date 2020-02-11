function focus() {
    let sections = document.getElementsByTagName('div');

    sections[0].addEventListener('click', (ev) => {
        let section;

        for (let index = 1; index < sections.length; index++) {

            sections[index].classList.remove("focused");

            // sections[index].style.backgroundColor = "";

        }

        if (ev.target.nodeName !== 'DIV') {
            section = ev.target.parentElement;
        }
        else {
            section = ev.target;
        }

        section.classList.add("focused");
        console.log(section.className)
        //section.style.backgroundColor = "grey";
    })
}