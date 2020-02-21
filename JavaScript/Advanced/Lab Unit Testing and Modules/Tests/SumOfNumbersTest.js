const sum = require('../SumOfNumbers');
let assert = require('chai').assert;

describe('sum() behaviour', () => {
    it('should return correct sum', () => {
        let result = sum([1, 2, 3, 4]);
        assert.equal(result, 10);
    })

    it('should return NaN if input is not Array',()=>{
        let result = sum('Test');
        assert.isNaN(result);
    })

    it('should return zero if input is empty string',()=>{
        let result = sum('');
        assert.equal(result,0);
    })
})