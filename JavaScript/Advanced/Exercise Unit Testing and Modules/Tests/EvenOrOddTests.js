const isOddOrEven = require('../EvenOrOdd');
let assert = require('chai').assert;

describe('evenOrodd behaviour', () => {
    it('should return undefined is input is not a string', () => {
        assert.isUndefined(isOddOrEven(3));
        assert.isUndefined(isOddOrEven({}));
        assert.isUndefined(isOddOrEven(['3']));
        assert.isUndefined(isOddOrEven(3.12));
    })

    it('should return odd on odd numbers input', () => {
        assert.equal(isOddOrEven('3'), 'odd')
        assert.equal(isOddOrEven('723'), 'odd')
        assert.equal(isOddOrEven('11234'), 'odd')
    })

    it('should return even on even numbers input', () => {
        assert.equal(isOddOrEven('02'), 'even')
        assert.equal(isOddOrEven('6234'), 'even')
        assert.equal(isOddOrEven('121213'), 'even')
    })

})