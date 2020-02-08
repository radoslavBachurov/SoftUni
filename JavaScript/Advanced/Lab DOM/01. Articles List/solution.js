function createArticle() {

	let titleElement = document.getElementById('createTitle');
	let textInput = document.getElementById('createContent');
	let articles = document.getElementById('articles');

	let headTitle = document.createElement('h3');
	headTitle.appendChild(document.createTextNode(titleElement.value));

	let textOutput = document.createElement('p');
	textOutput.appendChild(document.createTextNode(textInput.value));

	if (titleElement !== '' && textInput !== '') {
		articles.appendChild(headTitle);
		articles.appendChild(textOutput);
	}

	titleElement.value = '';
	textInput.value = '';

}