import { apiKey, listBooks, createBook, updateBook, deleteBook } from "./firebaseRequests.js";

(function () {
    let loadBtn = document.getElementById("loadBooks");
    let submit = document.querySelector("body > form > button");
    let body = document.querySelector("body > table > tbody");
    let table = document.querySelector("body > table > tbody");

    loadBtn.addEventListener('click', loadBooksAction);
    submit.addEventListener('click', submitAction);
    table.addEventListener('click', selectBook);

    function selectBook(ev) {
        let target = ev.target;
        let element = target.closest("tr");

        if (target.textContent === 'Edit') {
            editAction(element);
        }
        else if (target.textContent === 'Delete') {
            dltAction(element);
        }
        else {
            loadBook(element);
        }
    }

    async function submitAction(ev) {
        ev.preventDefault();
        let title = document.getElementById("title");
        let author = document.getElementById("author");
        let isbn = document.getElementById("isbn");

        let newObj = { "title": title.value, "author": author.value, "isbn": isbn.value };
        try {
            await createBook(newObj)
            loadBooksAction();
        } catch (error) {
            console.error(error);
        }

        title.value = '';
        author.value = '';
        isbn.value = '';
    }

    function loadBooksAction() {
        body.innerHTML = '';
        try {
            listBooks()
                .then((data) => { addElemetsToTable(data) });
        } catch (error) {
            console.error(error);
        }

    }

    function addElemetsToTable(data) {
        for (const key in data) {
            let newEl = document.createElement('tr');
            newEl.setAttribute("data-book-id", key);
            newEl.innerHTML =
                `<td>${data[key].title}</td>
            <td>${data[key].author}</td>
            <td>${data[key].isbn}</td>
            <td>
                <button>Edit</button>
                <button>Delete</button>
            </td>`;

            let editBtn = newEl.getElementsByTagName('button')[0];
            let dltBtn = newEl.getElementsByTagName('button')[1];

            body.appendChild(newEl);
        }
    }

    async function editAction(element) {
        let id = element.getAttribute("data-book-id");
        let title = document.getElementById("title");
        let author = document.getElementById("author");
        let isbn = document.getElementById("isbn");

        let newObj = { "title": title.value, "author": author.value, "isbn": isbn.value };
        try {
            await updateBook(id, newObj)
            loadBooksAction()

        } catch (error) {
            console.error(error);
        }

        title.value = '';
        author.value = '';
        isbn.value = '';
    }

    async function dltAction(element) {
        let id = element.getAttribute("data-book-id");
        try {
            await deleteBook(id);
            loadBooksAction()

        } catch (error) {
            console.error(error);
        }
    }

    function loadBook(element) {

        let info = element.getElementsByTagName("td");

        document.getElementById("title").value = info[0].textContent;
        document.getElementById("author").value = info[1].textContent;
        document.getElementById("isbn").value = info[2].textContent;
    }

})();