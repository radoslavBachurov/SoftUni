const isSymmetric = require('../Check for Symmetry');
let assert = require('chai').assert;

describe('isSymmetric() behavior', () => {
    it('if input is not an array should return false', () => {

        assert.isFalse(isSymmetric('test'));
        assert.isFalse(isSymmetric(1));
        assert.isFalse(isSymmetric({}));
        assert.isFalse(isSymmetric(''));
        assert.isFalse(isSymmetric([-1,2,1]));
      
    })

    it('if array is symetric return true', () => {

        assert.isTrue(isSymmetric([5,'hi',{a:5},new Date(),{a:5},'hi',5]));
        assert.isTrue(isSymmetric([1, 5, 5, 1]));
        assert.isTrue(isSymmetric([0]));
    })

    it('if array is not symetric return false', () => {

        assert.isFalse(isSymmetric([1, 2, 3, 1]));
        assert.isFalse(isSymmetric([1, 8, 5, 1]));
        assert.isFalse(isSymmetric([0, 2, 5, 4, 2, 0]));
    })
    
})