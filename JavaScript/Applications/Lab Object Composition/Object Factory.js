function solve(input) {
    let inputArr = JSON.parse(input);

    let newObject = inputArr.reduce((acc, curr) => {
        Object.assign(acc, curr);
        return acc;
    }, {})

    return newObject;
}

console.log(solve(`[{"canFly": true},{"canMove":true, "doors": 4},{"capacity": 255},{"canFly":true, "canLand": true}]`));