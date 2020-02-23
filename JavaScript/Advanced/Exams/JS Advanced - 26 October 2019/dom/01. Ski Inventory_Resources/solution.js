function solve() {

   let nameOfItem = document.querySelector("#add-new > input[type=text]:nth-child(2)");
   let quantityOfItem = document.querySelector("#add-new > input[type=text]:nth-child(3)");
   let priceOfItem = document.querySelector("#add-new > input[type=text]:nth-child(4)");
   let addButton = document.querySelector("#add-new > button");
   let availableProductList = document.querySelector("#products > ul");
   let filterButton = document.querySelector("#products > div > button");
   let filterCriteria = document.querySelector("#filter");
   let totalPrice = document.querySelector("body > h1:nth-child(4)");
   let myProducts = document.querySelector("#myProducts > ul");
   let buyButton = document.querySelector("#myProducts > button");

   let totalPriceSum = 0;

   filterButton.addEventListener('click', () => {
      let filterBy = filterCriteria.value;
      let liElements = availableProductList.getElementsByTagName('li');

      for (const element of liElements) {
         let spanElement = element.getElementsByTagName('span')[0];
         if (!spanElement.textContent.toLowerCase().includes(filterBy.toLowerCase())) {
            element.style.display = 'none';
         }
      }
   })

   addButton.addEventListener(`click`, (event) => {
      event.preventDefault();
      let liElement = document.createElement('LI');

      let spanElement = document.createElement('span');
      spanElement.appendChild(document.createTextNode(nameOfItem.value));

      let strongElement = document.createElement('strong');
      strongElement.appendChild(document.createTextNode(`Available: ${quantityOfItem.value}`));

      let secondStrongElement = document.createElement('strong');
      secondStrongElement.appendChild(document.createTextNode(priceOfItem.value));

      let button = document.createElement('button');
      button.appendChild(document.createTextNode("Add to Client's List"));
      button.addEventListener('click', AddClient);

      let divButton = document.createElement(`div`);

      divButton.appendChild(secondStrongElement);
      divButton.appendChild(button);
      
      liElement.appendChild(spanElement);
      liElement.appendChild(strongElement);
      liElement.appendChild(divButton);
     

      availableProductList.appendChild(liElement);
      nameOfItem.value = '';
      priceOfItem.value = '';
      quantityOfItem.value = '';
   })

   function AddClient(ev) {
      
      let price = Number((ev.target.parentElement.parentElement.getElementsByTagName('strong')[1].textContent));

      totalPriceSum += price;
      totalPrice.textContent = `Total Price: ${totalPriceSum.toFixed(2)}`;

      let available = ev.target.parentElement.parentElement.getElementsByTagName('strong')[0];
      let number = Number(available.textContent.split(':')[1]);
      AddToMyCard(ev.target.parentElement.parentElement);
      number--;
      if (number == 0) {

         availableProductList.removeChild(ev.target.parentElement.parentElement);
      }
      else {
         available.textContent = `Available: ${number}`;
      }
   }

   function AddToMyCard(toAdd) {

      let name = toAdd.getElementsByTagName('span')[0].textContent;
      let price = toAdd.getElementsByTagName('strong')[1].textContent;

      let liElement = document.createElement('LI');
      liElement.appendChild(document.createTextNode(name));

      let strongElement = document.createElement('strong');
      strongElement.appendChild(document.createTextNode(price));

      liElement.appendChild(strongElement);
      myProducts.appendChild(liElement);
   }

   buyButton.addEventListener('click', () => {
      myProducts.innerHTML = '';
      totalPrice.textContent = `Total Price: 0.00`;
      totalPriceSum = 0;
   })
}