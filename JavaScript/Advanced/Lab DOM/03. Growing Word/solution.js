function growingWord() {

  let text = document.getElementsByTagName('p')[0];
  let size = text.style.fontSize;
  let color = text.style.color;

  if(color == ''){
    text.style.color = 'blue'
    text.style.fontSize  = '2px';
  }
  else if(color == 'blue'){
    text.style.color = 'green'
    text.style.fontSize  = '4px';
  }
  else if(color == 'green'){
    text.style.color = 'red'
    text.style.fontSize  = '8px';
  }
  else if(color == 'red'){
    text.style.color = 'blue'
    text.style.fontSize  = '2px';
  }
  
}