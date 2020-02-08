function solve() {
   let sendButton = document.getElementById('send');
   let chatInput = document.getElementById('chat_input');
   let messageField = document.getElementById('chat_messages');

   sendButton.addEventListener('click', (e) => {
      let newMessage = document.createElement('div');
      newMessage.innerHTML = chatInput.value;
      newMessage.classList.add('message','my-message');
      messageField.appendChild(newMessage);
      chatInput.value = '';
   })
}


