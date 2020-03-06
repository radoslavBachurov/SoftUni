function carHelper(carInput) {
    let carParameters = carInput;

    let engineTypes = [{ 'power': 90, 'volume': 1800 },
    { 'power': 120, 'volume': 2400 },
    { 'power': 200, 'volume': 3500 }]

    let carriageTypes = [{ 'type': 'hatchback', 'color': carParameters.color },
    { 'type': 'coupe', 'color': carParameters.color }];

    let size = carParameters.wheelsize % 2 == 0 ? carParameters.wheelsize - 1 : carParameters.wheelsize;

    return {
        'model': carParameters.model,
        'engine': engineTypes.filter(x => x.power >= carParameters.power)[0],
        'carriage': carriageTypes.filter(x => x.type == carParameters.carriage)[0],
        'wheels': [size, size, size, size]
    }
}

console.log(carHelper({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}
))







