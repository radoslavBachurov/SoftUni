function getInfo() {
    let input = document.getElementById('stopId');
    let url = `https://judgetests.firebaseio.com/businfo/${input.value}.json`;

    fetch(url)
        .then((info) => info.json())
        .then((data) => {
            let busesInfo = Object.entries(data.buses);
            document.getElementById('stopName').textContent = data.name;
            let busesOutput = document.getElementById('buses');
            //busesOutput.innerHTML = '';

            for ([number, time] of busesInfo) {
                let newEl = document.createElement('li');
                newEl.textContent = `Bus ${number} arrives in ${time}`;
                busesOutput.appendChild(newEl);
            }

            document.getElementById('stopId').value = '';
        })
        .catch((error) => {
            document.getElementById('stopName').textContent = 'Error!';
            //document.getElementById('buses').innerHTML = '';
        })
    document.getElementById('buses').innerHTML = '';
}