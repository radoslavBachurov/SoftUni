function solve(input) {
    let inputArr = input;
    let gladiators = {};

    function gladiatorFight(gladInfo) {
        let [first, second] = gladInfo.split(' vs ');

        if (gladiators.hasOwnProperty(first) && gladiators.hasOwnProperty(second)) {
            let skillsA = gladiators[first];
            let skillsB = gladiators[second];
            for (const firstTechs in skillsA) {
                for (const secondTechs in skillsB) {
                    if (firstTechs === secondTechs) {
                        if (skillsA[firstTechs] > skillsB[secondTechs]) {
                            delete gladiators[second];
                        }
                        else if (skillsA[firstTechs] < skillsB[secondTechs]) {
                            delete gladiators[first];
                        }
                    }
                }
            }
        }

    }

    let command = inputArr.shift();
    while (command !== 'Ave Cesar') {
        if (command.includes(' -> ')) {
            const commandArr = command.split('->').map(x => x.trim());
            let name = commandArr[0];
            let tech = commandArr[1];
            let skill = Number(commandArr[2]);

            if (!gladiators[name]) {
                gladiators[name] = {};
            }
            if (!gladiators[name][tech]) {
                gladiators[name][tech] = skill;
            }
            else if (gladiators[name][tech] < skill) {
                gladiators[name][tech] = skill;
            }

        }
        else {
            gladiatorFight(command);

        }
        command = inputArr.shift();
    }

    let keysProps = Object.entries(gladiators);
    let gladiatorTier = [];
    for (const iterator of keysProps) {
        let name = iterator[0];
        let props = Object.entries(iterator[1]);
        var sum = props.map(a => a[1]).reduce((a, b) => a + b)

        gladiatorTier.push([name, props, sum]);
    }

    gladiatorTier.sort((a, b) => {
        if (b[2] - a[2] != 0) {
            return b[2] - a[2];
        }
        else {
            return a[0].localeCompare(b[0]);
        }
    })

    for (const iterator of gladiatorTier) {
        console.log(`${iterator[0]}: ${iterator[2]} skill`);

        iterator[1].sort((a, b) => {
            if (b[1] - a[1] != 0) {

                return b[1] - a[1];
            }
            else {
                return a[0].localeCompare(b[0]);
            }
        })

        for (const prop of iterator[1]) {
            console.log(`- ${prop[0]} <!> ${prop[1]}`);
        }
    }

}

solve(['Pesho -> Duck -> 400',
    'Julius -> Shield -> 150',
    'Gladius -> Heal -> 200',
    'Gladius -> Support -> 250',
    'Gladius -> Shield -> 250',

    'Gladius vs Julius',
    'Gladius vs Gosho',
    'Ave Cesar']
);