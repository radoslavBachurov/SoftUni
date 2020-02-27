function getArticleGenerator(articles) {
    let articlesArchive = articles;
    let content = document.getElementById('content');

    return function show() {
        if (articlesArchive.length !== 0) {
            let newEl = document.createElement('article');
            newEl.textContent = articlesArchive.shift();
            content.appendChild(newEl);
        }
    }
}
