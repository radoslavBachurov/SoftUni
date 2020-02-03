function solve(input) {
    let inputSet = new Set();
    input.forEach(element => {
        inputSet.add(element);
    });
    let valuesArr = Array.from(inputSet.values());

    let sorted = Array.from(inputSet.values()).sort((a, b) => {
        if (a.length !== b.length) {
            return a.length - b.length;
        }
        return a.localeCompare(b);
    })

    console.log(sorted.join('\n'));

}

solve(['Denise',
    'Ignatius',
    'Iris',
    'Isacc',
    'Indie',
    'Dean',
    'Donatello',
    'Enfuego',
    'Benjamin',
    'Biser',
    'Bounty',
    'Renard',
    'Rot']
);

