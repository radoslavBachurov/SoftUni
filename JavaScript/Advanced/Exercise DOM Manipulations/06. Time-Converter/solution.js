function attachEventsListeners() {

    let mainScreen = document.getElementsByTagName('main')[0];

    mainScreen.addEventListener('click', (ev) => {
        let target = ev.target.value;

        if (target == 'Convert') {
            let parent = ev.target.parentElement;
            let textBox = parent.getElementsByTagName('input')[0];
            let receivedMeasure = textBox.id;
            let inputTime = Number(textBox.value);

            switch (receivedMeasure) {
                case 'days':
                    inputTime = inputTime * 24 * 60 * 60;
                    break;
                case 'hours':
                    inputTime = inputTime * 60 * 60;
                    break;
                case 'minutes':
                    inputTime = inputTime * 60;
                    break;
                case 'seconds':

                    break;
            }

            let converter = {
                'days': () => { return inputTime / 60 / 60 / 24 },
                'hours': () => { return inputTime / 60 / 60 },
                'minutes': () => { return inputTime / 60 },
                'seconds': () => { return inputTime }
            };

            document.getElementById('days').value = converter.days();
            document.getElementById('hours').value = converter.hours();
            document.getElementById('minutes').value = converter.minutes();
            document.getElementById('seconds').value = converter.seconds();

        }

    })
}

