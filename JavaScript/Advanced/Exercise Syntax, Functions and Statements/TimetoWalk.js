function solve(numberSteps, stepLenghtMetres, speedKMH) {
    let distance = numberSteps * stepLenghtMetres;
    let numberBreaks = parseInt(distance / 500);
    let timeWalking = (distance / 1000) / speedKMH;
    let totalTimeMinutes = (timeWalking * 60) + numberBreaks;

    let hours = parseInt(totalTimeMinutes / 60);
    let minutes = parseInt(totalTimeMinutes);
    let seconds = Math.ceil((totalTimeMinutes - minutes) * 60);

    let strHours = hours;
    let strMinutes = minutes;
    let strSeconds = seconds;
    if (hours < 10) {
        strHours = '0' + hours;
    }
    if (minutes < 10) {
        strMinutes = '0' + minutes;
    }
    if (seconds < 10) {
        strSeconds = '0' + seconds;
    }

    console.log(`${strHours}:${strMinutes}:${strSeconds}`)
}

solve(2564, 0.70, 5.5);