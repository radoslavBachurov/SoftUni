const createCalculator = require('../AddSubtract');
let assert = require('chai').assert;


describe('AddSubstract() behaviour', () => {

    let calculator;

    beforeEach(function () {
        calculator = createCalculator();
    })

    it('Initial Value must be 0', () => {
        let result = calculator.get();
        assert.equal(calculator.get(), 0);
    })

    it('add func should work correctly', () => {
        calculator.add(3);
        calculator.add(2);

        assert.equal(calculator.get(), 5);
    })

    it('subtract func should work correctly', () => {
        calculator.subtract(3);
        calculator.subtract(2);

        assert.equal(calculator.get(), -5);
    })

    it('should return NaN after adding string', () => {
       
        calculator.add('sad');
        assert.isNaN(calculator.get());

    })

    it('should return NaN after substracting string', () => {
        calculator.subtract('asd');
        assert.isNaN(calculator.get());

    })

    it('Should return correct value after work with float numbers', () => {
        calculator.subtract(2.5);
        calculator.subtract(2.5);

        assert.equal(calculator.get(), -5);

        calculator.add(3.5);
        calculator.add(2.5);

        assert.equal(calculator.get(), 1);
    })

    it('Should work correctly after apply multiple operations', () => {
        calculator.subtract(3);
        calculator.add(2);
        calculator.subtract(-3);
        calculator.add(-2);

        assert.equal(calculator.get(), 0);
    })

    it("should return 2 after add(10); subtract('7'); add('-2'); subtract(-1)", function () {
        calculator.add(10);
        calculator.subtract('7');
        calculator.add('-2');
        calculator.subtract(-1);
        let value = calculator.get();
        expect(value).to.be.equal(2);
})
})