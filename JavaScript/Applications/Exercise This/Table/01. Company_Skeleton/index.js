function solve() {
   let sectionToChange = document.getElementsByTagName('tbody')[0];
   let allElements = sectionToChange.getElementsByTagName('tr');

   sectionToChange.addEventListener('click', (ev) => {
      let element = ev.target.parentElement;

      if (element.style.backgroundColor !== "") {
         element.style.backgroundColor = '';
         return;
      }
      
      for (const el of allElements) {
         el.style.backgroundColor = ''
      }

      element.style.backgroundColor = "#413f5e";

   })
}
