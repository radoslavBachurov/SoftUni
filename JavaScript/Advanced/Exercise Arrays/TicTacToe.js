function solve(moves) {
    const movesArr = moves.slice();

    const table = [[false, false, false],
    [false, false, false],
    [false, false, false]];
    let turn = 'X';

    for (let index = 0; index < moves.length; index++) {
        let coordinates = movesArr.shift().split(' ');
        let row = Number(coordinates[0]);
        let coll = Number(coordinates[1]);

        if (table[row][coll] != false) {
            console.log("This place is already taken. Please choose another!")
            continue;
        }
        else {
            table[row][coll] = turn;
            let resultWinner = checkForWinner(table);
            if (resultWinner != 'playing') {
                let strTable = printTable(table);
                return `${resultWinner}\n${strTable}`;
            }

            let resultFullTable = checkForFullTable(table);
            if (resultFullTable != 'playing') {
                let strTable = printTable(table);
                return `${resultFullTable}\n${strTable}`;
            }

            if (turn == 'X') {
                turn = 'O';
            }
            else {
                turn = 'X';
            }
        }
    }

    function printTable(table) {
        let toReturn = '';
    
        for (let index = 0; index < table.length; index++) {
    
            let strRow = table[index].join('\t');
            toReturn += `${strRow}\n`;
        }
    
        return toReturn;
    }
    
    
    function checkForFullTable(table) {
    
        for (let row = 0; row < table.length; row++) {
            for (let coll = 0; coll < table.length; coll++) {
                if (table[row][coll] == false) {
                    return 'playing';
                }
            }
        }
        return "The game ended! Nobody wins :(";
    }
    
    function checkForWinner(table) {
    
        for (let index = 0; index < table.length; index++) {
            let arrToCheck = table[index];
            let isMagic = arrToCheck.every((val, i, arr) => val === arr[0])
    
            if (isMagic && arrToCheck[0] != false) {
                return `Player ${arrToCheck[0]} wins!`;
            }
        }
    
        for (let index = 0; index < table.length; index++) {
            let arrToCheck = [table[0][index], table[1][index], table[2][index]];
            let isMagic = arrToCheck.every((val, i, arr) => val === arr[0])
    
            if (isMagic && arrToCheck[0] != false) {
                return `Player ${arrToCheck[0]} wins!`;
            }
        }
    
        let arrToCheck = [table[0][0], table[1][1], table[2][2]];
        let isMagic = arrToCheck.every((val, i, arr) => val === arr[0])
        if (isMagic && arrToCheck[0] != false) {
            return `Player ${arrToCheck[0]} wins!`;
        }
    
        arrToCheck = [table[0][2], table[1][1], table[2][0]];
        isMagic = arrToCheck.every((val, i, arr) => val === arr[0])
        if (isMagic && arrToCheck[0] != false) {
            return `Player ${arrToCheck[0]} wins!`;
        }
    
        return 'playing';
    }
}

console.log(solve(["0 1",
"0 0",
"0 2",
"2 0",
"1 0",
"1 2",
"1 1",
"2 1",
"2 2",
"0 0"]

));