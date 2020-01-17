function solve(input) {

    let newObject = {};

    for (let index = 0; index < input.length; index += 2) {
        let name = input[index];
        let quantity = Number(input[index + 1]);

        newObject[name] = quantity;
    }

    console.log(newObject);
}

solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);