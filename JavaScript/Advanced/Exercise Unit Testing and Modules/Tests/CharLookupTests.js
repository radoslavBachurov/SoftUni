const lookupChar = require('../CharLookup');
let assert = require('chai').assert;

describe('charLookup behaviour', () => {
    it('if input string is not string return undefined', () => {
        assert.isUndefined(lookupChar(1, 2));
        assert.isUndefined(lookupChar({}, 2));
        assert.isUndefined(lookupChar([], 2));
    })

    it('if input index is not number return undefined', () => {
        assert.isUndefined(lookupChar('input', '2'));
        assert.isUndefined(lookupChar('input', 2.5));
        assert.isUndefined(lookupChar('input', 'test'));
    })


    it('if string length is smaller or equal to index or index is less than zero return Incorrect index', () => {
        assert.equal(lookupChar('input', 5), 'Incorrect index');
        assert.equal(lookupChar('input', 7), 'Incorrect index');
        assert.equal(lookupChar('input', -9), 'Incorrect index');
    })

    it('Check if func is returning correct characters', () => {
        assert.equal(lookupChar('input', 0), 'i');
        assert.equal(lookupChar('input', 4), 't');
        assert.equal(lookupChar('input', 2), 'p');
    })
})