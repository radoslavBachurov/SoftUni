export const apiKey = "https://testapp-72069.firebaseio.com/";

export let listBooks = function () {
    return fetch(apiKey + "books/.json").then((responce) => responce.json());
}

export let createBook = function (book) {
    return fetch(apiKey + "books/.json", {
        method: 'POST',
        body: JSON.stringify(book)
    });
}

export let updateBook = function (id, body) {
    return fetch(apiKey + `books/${id}.json`, {
        method: 'PUT',
        body: JSON.stringify(body)
    })
}

export let deleteBook = function (id) {
    return fetch(apiKey + `books/${id}.json`, {
        method: 'DELETE'
    });
}