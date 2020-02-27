function solve(area, vol, input) {

    let output = [];

    for (const coordinates of input) {
        let x = coordinates['x'];
        let y = coordinates['y'];
        let z = coordinates['z'];

        let object = { 'x': x, 'y': y, 'z': z, 'area': area, 'volume': vol };
        output.push({ 'area': object.area(), 'volume': object.volume() });
    }
    return output;
}

console.log(solve(area, vol,[{"x":"10","y":"-22","z":"10"},{"x":"47","y":"7","z":"-5"},{"x":"55","y":"8","z":"0"},{"x":"100","y":"100","z":"100"},{"x":"55","y":"80","z":"250"}]));
function area() {
    return this.x * this.y;
};

function vol() {
    return this.x * this.y * this.z;
};

