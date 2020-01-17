function solve(coordinates) {
    let x1 = coordinates[0];
    let y1 = coordinates[1];
    let x2 = coordinates[2];
    let y2 = coordinates[3];

    findDistance(x1, y1, 0, 0);
    findDistance(x2, y2, 0, 0);
    findDistance(x1, y1, x2, y2);

    function findDistance(x1, y1, x2, y2) {

        let distance = Math.sqrt(Math.pow((x1 - x2), 2) + Math.pow((y1 - y2), 2));

        if (checkIsValid(distance)) {
            console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`)
        } else {
            console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`)
        }
    }

    function checkIsValid(distance) {
        return distance % 1 === 0;
    }
}

solve([3, 0, 0, 4]);

//distance = math.sqrt(math.pow((x2-x1),2)+math.pow((y2-y1),2))