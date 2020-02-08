function solve() {
   let shoppingCard = document.querySelector('.shopping-cart');
   let textInfo = document.getElementsByTagName('textarea')[0];

   let totalSum = 0;
   let boughtProducts = new Set();

   let shopping = (ev) => {
      let textContent = ev.target.innerHTML.trim();

      if (textContent == 'Add') {
         let product = ev.path[2];
         
         let price = Number(product.querySelector('.product-line-price').textContent);
         let name = product.querySelector('.product-title').textContent;

         totalSum += price;
         boughtProducts.add(name);
         textInfo.value += (`Added ${name} for ${price} to the cart.\n`)

       }
      else if (textContent == 'Checkout') {

         let checkoutText = `You bought ${(Array.from(boughtProducts)).join(', ')} for ${totalSum.toFixed(2)}.`;
         textInfo.value += checkoutText;
         shoppingCard.removeEventListener('click', shopping);
      }
   }

   shoppingCard.addEventListener('click', shopping)
}