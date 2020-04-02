import { apiKey, liststudents, createStudent } from "./firebaseRequests.js";

(function () {
    let loadBtn = document.getElementById("loadBooks");
    let submit = document.querySelector("body > form > button");
    let body = document.querySelector("body > table > tbody");

    submit.addEventListener('click', submitAction);
    loadBtn.addEventListener('click', loadStudentsAction);

    async function submitAction(ev) {
        ev.preventDefault();
        let firstName = document.getElementById("firstName");
        let lastName = document.getElementById("lastName");
        let id = document.getElementById("id");
        let facultyNumber = document.getElementById("facultyNumber");
        let grade = document.getElementById("grade");

        if (firstName.value && lastName.value && !isNaN(id.value) && !isNaN(facultyNumber.value) && !isNaN(grade.value)) {
            let newObj = { "firstName": firstName.value, "lastName": lastName.value, "id": id.value, "facultyNumber": facultyNumber.value, "grade": grade.value };
            try {
                await createStudent(newObj, id.value)
                loadStudentsAction()
            } catch (error) {
                console.error(error);
            }

            firstName.value = '';
            lastName.value = '';
            id.value = '';
            facultyNumber.value = '';
            grade.value = '';
        }
    }

    function loadStudentsAction() {
        body.innerHTML = '';
        try {
            liststudents()
                .then((students) => {
                    addElemetsToTable(students);
                })
        } catch (error) {
            console.error(error);
        }

    }

    function addElemetsToTable(data) {
        for (const key in data) {
            if (data[key]) {
                let newEl = document.createElement('tr');
                newEl.setAttribute("data-book-id", key);
                newEl.innerHTML =
                    `<th>${data[key].id}</th>
                <th>${data[key].lastName}</th>
                <th>${data[key].firstName}</th>
                <th>${data[key].facultyNumber}</th>
                <th>${data[key].grade}</th>`;

                body.appendChild(newEl);
            }
        }
    }

})();