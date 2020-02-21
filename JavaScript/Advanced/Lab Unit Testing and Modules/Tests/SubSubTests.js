const sum = require('../SubSum');
let assert = require('chai').assert;

describe('SubSum behaviour', () => {
    it('if first element not an array should return NaN', () => {
        let result = sum(5, 0, 5);
        assert.isNaN(result)
    })

    it('If the start index is less than zero, start index must be a zero', () => {
        let result = sum([1, 2, 3, 4], -3, 3);
        assert.equal(result, 10)
    })

    it('If the end index is outside the bounds of the array, last index is end of the array', () => {
        let result = sum([1, 2, 3, 4], 0, 10);
        assert.equal(result, 10)
    })
})