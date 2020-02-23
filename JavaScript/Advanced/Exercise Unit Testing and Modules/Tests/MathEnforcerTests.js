const mathEnforcer = require('../MathEnforcer');
let assert = require('chai').assert;


describe('mathEnforcer() behaviour', () => {
    it('addFive function should return undefined if num is not a number', () => {
        assert.isUndefined(mathEnforcer.addFive('3'));
        assert.isUndefined(mathEnforcer.addFive({}));
        assert.isUndefined(mathEnforcer.addFive([3, 2]));
    })

    it('addFive function should return correct answer if num is a number', () => {
        assert.equal(mathEnforcer.addFive(5), 10);
        assert.equal(mathEnforcer.addFive(4.3), 9.3);
        assert.equal(mathEnforcer.addFive(-4), 1);
        assert.equal(mathEnforcer.addFive(-3.44), 5 - 3.44);
    })

    it('subtractTen function should return undefined if num is not a number', () => {
        assert.isUndefined(mathEnforcer.subtractTen('3'));
        assert.isUndefined(mathEnforcer.subtractTen({}));
        assert.isUndefined(mathEnforcer.subtractTen([3, 2]));
    })

    it('subtractTen function should return correct answer if num is a number', () => {
        assert.equal(mathEnforcer.subtractTen(5), -5);
        assert.equal(mathEnforcer.subtractTen(4.3), -5.7);
        assert.equal(mathEnforcer.subtractTen(-4), -14);
        assert.equal(mathEnforcer.subtractTen(-3.44), -13.44);
    })

    it('sum function should return undefined if num is not a number', () => {
        assert.isUndefined(mathEnforcer.sum('3', 4));
        assert.isUndefined(mathEnforcer.sum({}, 3));
        assert.isUndefined(mathEnforcer.sum([3, 2], 5));
        assert.isUndefined(mathEnforcer.sum(4, '3'));
        assert.isUndefined(mathEnforcer.sum(3, {}));
        assert.isUndefined(mathEnforcer.sum(4, [3, 2]));
    })

    it('sum function should return correct answer if num is a number', () => {
        assert.equal(mathEnforcer.sum(5,5), 10);
        assert.equal(mathEnforcer.sum(4.3,3.4), 7.699999999999999);
        assert.equal(mathEnforcer.sum(-4,10.3), 6.300000000000001);
        assert.equal(mathEnforcer.sum(-3.44,-5), -8.44);
    })
})
