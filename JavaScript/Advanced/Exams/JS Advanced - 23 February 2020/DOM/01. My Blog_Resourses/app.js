function solve() {
   let author = document.getElementById(`creator`);
   let title = document.getElementById(`title`);
   let category = document.getElementById(`category`);
   let content = document.getElementById('content');
   let createButton = document.querySelector("body > div > div > aside > section:nth-child(1) > form > button");
   let articlesSection = document.querySelector("body > div > div > main > section");
   let archiveSection = document.getElementsByClassName("archive-section")[0];

   createButton.addEventListener('click', () => {
      //event.preventDefault();

      let articleElement = document.createElement('article');

      let jsElement = document.createElement('h1');
      jsElement.appendChild(document.createTextNode(title.value));
      //
      let pCategory = document.createElement('p');
      pCategory.appendChild(document.createTextNode('Category:'));
      let pStrongOne = document.createElement('strong');
      pStrongOne.appendChild(document.createTextNode(category.value));

      pCategory.appendChild(pStrongOne);
      //
      let pCreator = document.createElement('p');
      pCreator.appendChild(document.createTextNode('Creator:'));
      let pStrongtwo = document.createElement('strong');
      pStrongtwo.appendChild(document.createTextNode(author.value));

      pCreator.appendChild(pStrongtwo);
      //
      let pContent = document.createElement('p');
      pContent.appendChild(document.createTextNode(content.value));
      //
      let div = document.createElement('div');
      div.classList.add("buttons");

      let deleteButton = document.createElement('button');
      deleteButton.classList.add("btn");
      deleteButton.classList.add("delete");
      deleteButton.appendChild(document.createTextNode('Delete'));
      deleteButton.addEventListener('click', (ev) => {
         articlesSection.removeChild(ev.target.parentElement.parentElement);
      });

      let archiveButton = document.createElement('button');
      archiveButton.classList.add("btn");
      archiveButton.classList.add('archive');
      archiveButton.appendChild(document.createTextNode('Archive'));
      archiveButton.addEventListener('click', (ev) => {
         let title = ev.target.parentElement.parentElement.getElementsByTagName(`h1`)[0];

         let liElement = document.createElement('li');
         liElement.appendChild(document.createTextNode(title.textContent));
         let ulElement = archiveSection.getElementsByTagName('ul')[0];
         ulElement.appendChild(liElement);
         sortList(ulElement);
         articlesSection.removeChild(ev.target.parentElement.parentElement);

      });

      div.appendChild(deleteButton);
      div.appendChild(archiveButton);
      //
      articleElement.appendChild(jsElement);
      articleElement.appendChild(pCategory);
      articleElement.appendChild(pCreator);
      articleElement.appendChild(pContent);
      articleElement.appendChild(div);

      articlesSection.appendChild(articleElement);
   })

   function sortList(ulElement) {
      Array.from(ulElement.getElementsByTagName("li"))
         .sort((a, b) => a.textContent.localeCompare(b.textContent))
         .forEach(li => ulElement.appendChild(li));
   }
}

