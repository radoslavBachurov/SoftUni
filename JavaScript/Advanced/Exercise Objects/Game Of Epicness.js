function solve(inputOne, inputTwo) {
    const inputKingdoms = inputOne;
    const inputWars = inputTwo;

    const kingdomsList = {};
    const generalList = {};

    for (const kingdom of inputKingdoms) {
        let kingdomName = kingdom.kingdom;
        let generalName = kingdom.general;
        let armyCount = Number(kingdom.army);

        if (!kingdomsList.hasOwnProperty(kingdomName)) {
            kingdomsList[kingdomName] = { [generalName]: armyCount, 'wins': 0, 'losses': 0 };

        }

        else if (!kingdomsList[kingdomName].hasOwnProperty(generalName)) {
            kingdomsList[kingdomName][generalName] = armyCount;
        }
        else {
            kingdomsList[kingdomName][generalName] += armyCount;
        }
        generalList[generalName] = { 'wins': 0, 'losses': 0 }
    }

    for (const war of inputWars) {
        let atKingdom = war[0];
        let atGen = war[1];
        let defKingdom = war[2];
        let defGen = war[3];

        if (atKingdom !== defKingdom) {
            let atArmy = kingdomsList[atKingdom][atGen];
            let defArmy = kingdomsList[defKingdom][defGen];

            if (atArmy > defArmy) {
                kingdomsList[atKingdom][atGen] = parseInt(atArmy + atArmy * 0.1);
                generalList[atGen].wins++;
                kingdomsList[atKingdom].wins++;
                kingdomsList[defKingdom][defGen] = parseInt(defArmy - defArmy * 0.1);
                kingdomsList[defKingdom].losses++;
                generalList[defGen].losses++;

            }
            else if (atArmy < defArmy) {
                kingdomsList[atKingdom][atGen] = parseInt(atArmy - atArmy * 0.1);
                kingdomsList[atKingdom].losses++;
                generalList[atGen].losses++;
                kingdomsList[defKingdom][defGen] = parseInt(defArmy + defArmy * 0.1);
                kingdomsList[defKingdom].wins++;
                generalList[defGen].wins++;
            }
        }
    }

    let kingdomListArr = Object.entries(kingdomsList).sort((a, b) => {
        if (a[1].wins !== b[1].wins) {
            return b[1].wins - a[1].wins;
        }
        else if (a[1].losses !== b[1].losses) {
            return a[1].losses - b[1].losses;
        }
        else {
            return a[0].localeCompare(b[0]);
        }
    });

    console.log(`Winner: ${kingdomListArr[0][0]}`);
    let winner = kingdomListArr[0][1];
    let winnerInfo = Object.entries(winner);

    for (const key of winnerInfo.sort((a, b) => { return b[1] - a[1]; })) {
        let name = key[0];
        let army = key[1];

        if (key[0] !== 'wins' && key[0] !== 'losses') {
            console.log(`/\\general: ${name}`)
            console.log(`---army: ${army}`)
            console.log(`---wins: ${generalList[name].wins}`)
            console.log(`---losses: ${generalList[name].losses}`)
        }

    }
}

solve([ { kingdom: "Maiden Way", general: "Merek", army: 5000 },
{ kingdom: "Stonegate", general: "Merek", army: 4900 },
{ kingdom: "Stonegate", general: "Doran", army: 70000 },
{ kingdom: "YorkenShire", general: "Quinn", army: 0 },
{ kingdom: "YorkenShire", general: "Quinn", army: 2000 },
{ kingdom: "Maiden Way", general: "Berinon", army: 100000 } ],
[ ["YorkenShire", "Quinn", "Stonegate", "Merek"],
["Stonegate", "Merek", "Maiden Way", "Doran"],
["Stonegate", "Doran", "Maiden Way", "Merek"],
["Stonegate", "Ulric", "Maiden Way", "Merek"],
["Maiden Way", "Berinon", "Stonegate", "Ulric"] ]

);