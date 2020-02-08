function solve() {
   let searchButton = document.getElementById('searchBtn');
   let tableElements = document.querySelectorAll('body > table > tbody > tr');
   let input = document.getElementById('searchField');

   searchButton.addEventListener('click', () => {
      Array.from(document.querySelectorAll('.select')).map(x => x.classList.remove('select'));
      let inputValue = input.value.toLowerCase();

      for (const element of tableElements) {
         if (element.innerHTML.toLowerCase().includes(inputValue)) {
            element.classList.add("select");
         }
      }
      input.value = '';
   })
}