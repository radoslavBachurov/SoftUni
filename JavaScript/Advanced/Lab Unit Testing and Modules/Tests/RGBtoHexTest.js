const rgbToHexColor = require('../RGBtoHex');
let assert = require('chai').assert;

describe('rgbToHexcOLOR()', () => {
    it('if red is invalid should return undefined', () => {
        assert.isUndefined(rgbToHexColor(-1, 4, 10));
        assert.isUndefined(rgbToHexColor('b', 4, 10));
        assert.isUndefined(rgbToHexColor({}, 4, 10));
        assert.isUndefined(rgbToHexColor("", 4, 10));
    })

    it('if green is invalid should return undefined', () => {
        assert.isUndefined(rgbToHexColor(6, -1, 10));
        assert.isUndefined(rgbToHexColor(10, 'b', 10));
        assert.isUndefined(rgbToHexColor(44, {}, 10));
        assert.isUndefined(rgbToHexColor(34, "", 10));
    })

    it('if blue is invalid should return undefined', () => {
        assert.isUndefined(rgbToHexColor(13, 6, -1));
        assert.isUndefined(rgbToHexColor(45, 10, 'b'));
        assert.isUndefined(rgbToHexColor(12, {}));
        assert.isUndefined(rgbToHexColor(33, 34, ""));
    })

    it('if is valid should return correct result', () => {
        let result = rgbToHexColor(0, 255, 255);
        assert.equal(result,'#00FFFF');
    })
})