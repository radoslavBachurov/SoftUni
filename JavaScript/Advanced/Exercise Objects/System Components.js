function solve(input) {
    const inputArr = input;
    const listComponents = {};
    for (let index = 0; index < inputArr.length; index++) {
        let currComponenet = inputArr[index].split(' | ').filter(x => x != '');
        let mainComponent = currComponenet[0];
        let Component = currComponenet[1];
        let subComponent = currComponenet[2];

        if (!listComponents[mainComponent]) {
            listComponents[mainComponent] = {};
        }

        if (!listComponents[mainComponent][Component]) {
            listComponents[mainComponent][Component] = [];
        }

        listComponents[mainComponent][Component] = [...listComponents[mainComponent][Component], subComponent];

    }

    let sorted = Object.keys(listComponents).sort((a, b) => {
        if (Object.keys(listComponents[a]).length !== Object.keys(listComponents[b]).length) {
            return Object.keys(listComponents[b]).length - Object.keys(listComponents[a]).length
        }
        else {
            return a.localeCompare(b);
        }
    })

    for (let index = 0; index < sorted.length; index++) {
        let sortedSub = Object.keys(listComponents[sorted[index]]).sort((a, b) => {
            return Object.keys(listComponents[sorted[index]][b]).length - Object.keys(listComponents[sorted[index]][a]).length
        });
        console.log(sorted[index]);

        for (let i = 0; i < sortedSub.length; i++) {
            console.log(`|||${sortedSub[i]}`)
            console.log(`||||||${listComponents[sorted[index]][sortedSub[i]].join('\n||||||')}`)
        }
    }

}

solve(['SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security']
);
