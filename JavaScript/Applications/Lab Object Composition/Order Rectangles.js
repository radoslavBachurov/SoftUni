function createRectangles(input) {
    let inputArr = input;
    let rectangleObjects = [];

    for (let index = 0; index < inputArr.length; index++) {
        let width = Number(inputArr[index][0]);
        let height = Number(inputArr[index][1]);
        let area = () => { return width * height };
        let compareTo = (other) => { return other.area() - area() || other.width - width; }
        let newObject = { width, height, area, compareTo };
        rectangleObjects.push(newObject);
    }

    rectangleObjects.sort((a, b) => {
        return a.compareTo(b);
    });

    return rectangleObjects;
}
let rect = createRectangles([[1, 20], [20, 1], [5, 3], [5, 3]]);


console.log(rect);