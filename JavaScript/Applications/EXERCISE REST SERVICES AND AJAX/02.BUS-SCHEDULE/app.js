function solve() {
    let departButton = document.getElementById('depart');
    let arriveButton = document.getElementById('arrive');
    let infoBox = document.getElementById(`info`);
    let currStopID = '0361';
    let currStopName = `Depot`;

    function depart() {
        departButton.disabled = true;
        arriveButton.disabled = false;
        let url = `https://judgetests.firebaseio.com/schedule/${currStopID}.json`;
        fetch(url)
            .then((info) => info.json())
            .then((data) => {
                infoBox.textContent = `Next stop ${data.name}`;
                currStopID = data.next;
                currStopName = data.name;
            })
            .catch(() => {
            infoBox.textContent = 'Error';
                departButton.disabled = true;
                arriveButton.disabled = true;
            })
    }

    function arrive() {
        departButton.disabled = false;
        arriveButton.disabled = true;
        infoBox.textContent = `Arriving at ${currStopName}`;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();