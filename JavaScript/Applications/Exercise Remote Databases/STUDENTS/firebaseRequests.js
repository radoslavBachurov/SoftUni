
export const apiKey = "https://testapp-72069.firebaseio.com/";

export let liststudents = function () {
    return fetch(apiKey + "students/.json").then((responce) => responce.json());
}

export let createStudent = function (book, id) {
    return fetch(apiKey + `students/${id}/.json`, {
        method: 'PUT',
        body: JSON.stringify(book)
    });
}

// export let updateBook = function (id, body) {
//     return fetch(apiKey + `students/${id}.json`, {
//         method: 'PUT',
//         body: JSON.stringify(body)
//     });
// }

// export let deleteBook = function (id) {
//     return fetch(apiKey + `students/${id}.json`, {
//         method: 'DELETE'
//     });
// }