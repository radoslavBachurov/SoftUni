function solve() {
  let quiz = document.getElementById('quizzie');
  let correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];
  let sections = document.getElementsByTagName('section');
  let result = document.querySelector('.results-inner h1');

  let rightAnswers = 0;
  let currentstep = 0;

  let event = (ev) => {
    if (ev.target.className == 'answer-text') {
      sections[currentstep].style.display = 'none';
      currentstep++;

      if (correctAnswers.includes(ev.target.innerHTML)) {
        rightAnswers++;
      }
      if (currentstep == correctAnswers.length) {
        document.querySelector('#results').style.display = 'block';
        quiz.removeEventListener('click', event);
        result.innerHTML = rightAnswers == correctAnswers.length
          ? "You are recognized as top JavaScript fan!" : `You have ${rightAnswers} right answers`;
      }
      else {
        sections[currentstep].style.display = 'block';
      }
    }
  }

  quiz.addEventListener('click', event);
}
