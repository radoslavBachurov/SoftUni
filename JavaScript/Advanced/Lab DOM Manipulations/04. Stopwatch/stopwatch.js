function stopwatch() {
    let outputTime = document.getElementById('time');
    let startButton = document.getElementById('startBtn');
    let stopButton = document.getElementById('stopBtn');

    let timer = null;

    startButton.addEventListener('click', startClock);
    stopButton.addEventListener('click', stopClock);

    function stopClock() {
        startButton.disabled = false;
        stopButton.disabled = true;

        clearInterval(timer);

    }

    function startClock() {
        startButton.disabled = true;
        stopButton.disabled = false;
        outputTime.innerHTML = '00:00';

        let seconds = 0;
        let minutes = 0;
        timer = setInterval(tick, 1000);
F
        function tick() {
            seconds++;

            if (seconds == 60) {
                minutes++;
                seconds = 0;
            }

            outputTime.innerHTML = `${makeMeTwoDigits(minutes)}:${makeMeTwoDigits(seconds)}`;

            function makeMeTwoDigits(n) {
                return (n < 10 ? "0" : "") + n;
            }
        }
    }
}