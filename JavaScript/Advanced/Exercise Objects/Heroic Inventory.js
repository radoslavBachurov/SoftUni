function solve(input) {
    const inputArr = input;
    const allHeroes = [];

    for (let index = 0; index < inputArr.length; index++) {
        let currHeroInfo = inputArr[index].split(/\s*[/,]\s*/).filter(x => x != '');
        let heroName = currHeroInfo.shift();
        let heroLevel = +currHeroInfo.shift();
        let heroItems = [];
        heroItems = heroItems.concat(currHeroInfo);

        let newHero = {};
        newHero['name'] = heroName;
        newHero['level'] = heroLevel;
        newHero['items'] = heroItems;

        allHeroes.push(newHero);
    }

    return JSON.stringify(allHeroes);
}

console.log(solve(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']
));