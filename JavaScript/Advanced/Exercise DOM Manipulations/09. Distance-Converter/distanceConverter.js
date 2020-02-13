function attachEventsListeners() {
    let button = document.getElementById('convert');
    let inputUnits = document.getElementById('inputUnits');
    let outputUnits = document.getElementById('outputUnits');
    let inputBox = document.getElementById('inputDistance');
    let outputBox = document.getElementById('outputDistance');

    let toMetres = {
        'km': (x) => { return x * 1000 },
        'm': (x) => { return x * 1 },
        'cm': (x) => { return x * 0.01 },
        'mm': (x) => { return x * 0.001 },
        'mi': (x) => { return x * 1609.34 },
        'yrd': (x) => { return x * 0.9144 },
        'ft': (x) => { return x * 0.3048 },
        'in': (x) => { return x * 0.0254 }
    };

    let fromMetres = {
        'km': (x) => { return x / 1000 },
        'm': (x) => { return x / 1 },
        'cm': (x) => { return x / 0.01 },
        'mm': (x) => { return x / 0.001 },
        'mi': (x) => { return x / 1609.34 },
        'yrd': (x) => { return x / 0.9144 },
        'ft': (x) => { return x / 0.3048 },
        'in': (x) => { return x / 0.0254 }
    };

    button.addEventListener('click', () => {
        let distanceInMetres = toMetres[inputUnits.value](Number(inputBox.value));
        let converted = fromMetres[outputUnits.value](distanceInMetres);
        outputBox.value = converted;
    })
}