function solve() {
  let inputText = document.getElementById('input');
  let toAppend = document.getElementById('output');

  let text = inputText.textContent;
  let splittedText = text.split('.').filter(x => x != '');

  
  let textToAppend = '';
  for (let index = 0; index < splittedText.length; index++) {
    textToAppend += splittedText[index];

    if (index % 2 == 0 && index != 0) {
      let element = document.createElement("p");
      element.appendChild(document.createTextNode(textToAppend));
      toAppend.appendChild(element);
      textToAppend = '';
    }
  }

  if (textToAppend !== '') {
    let element = document.createElement("p");
    element.appendChild(document.createTextNode(textToAppend));
    toAppend.appendChild(element);
    console.log(textToAppend)
  }
  console.log(toAppend)
}