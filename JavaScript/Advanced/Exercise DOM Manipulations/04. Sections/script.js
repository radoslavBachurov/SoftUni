function create(words) {

   let toAtach = document.getElementById('content');

   for (let index = 0; index < words.length; index++) {

      let div = document.createElement('div');
      let para = document.createElement('p');
      let text = document.createTextNode(`${words[index]}`);

      para.appendChild(text);
      para.style.display = 'none';

      div.appendChild(para);
      toAtach.appendChild(div);

      div.addEventListener('click', () => {

         let para = div.childNodes[0];

         if (para.style.display === 'block') {
            para.style.display = 'none';
         }
         else {
            para.style.display = 'block';
         }

      })

      div.appendChild(para);
      toAtach.appendChild(div);

   }

}