let Parser = require("./solution.js");
let assert = require("chai").assert;

describe("MyTests", () => {
    describe('add entries method', () => {
        it('should return proper message', () => {
            let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');

            assert.equal(parser.addEntries("Steven:tech-support Edd:administrator"), 'Entries added!');
        })

    })

    describe('constructor tests', () => {
        it('log should be zero', () => {
            let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
            assert.equal(parser._log.length, 0);
        })

        it('data should be correct', () => {
            let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');

            assert.equal(parser._data[0]['Nancy'], "architect");
            assert.equal(parser._data[1]['John'], "developer");
            assert.equal(parser._data[2]['Kate'], "HR");

        })

        it('_addToLog should return added to log', () => {
            let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
            let message = parser._addToLog();
            assert.equal(message, "Added to log")
        })

        it('log should return correct value', () => {
            let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
            parser._addToLog('test')
            assert.equal(parser._log[0], `0: test`)
        })
    })

    describe('data method tested', () => {
        it('should add coorrect data in log', () => {
            let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
            let array = parser.data;

            assert.equal(array[0]['Nancy'], "architect")
            assert.equal(array[1]['John'], "developer")
            assert.equal(array[2]['Kate'], 'HR')

        })
    })

    describe('add entries method', () => {
        it('should add coorrect data in log', () => {
            let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
            let message = parser.addEntries("Steven:tech-support Edd:administrator");
            assert.equal(message, "Entries added!");

            let array = parser.data;

            assert.equal(array[3]['Steven'], 'tech-support')
            assert.equal(array[4]['Edd'], 'administrator')
            let arr = parser._log;
            assert.equal(arr[arr.length - 2], `0: addEntries`)
            assert.equal(arr[arr.length - 1], `1: getData`)
        })

        it('remove', () => {
            let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
            let message = parser.addEntries("Steven:tech-support Edd:administrator");
            let message2 = parser.removeEntry("Kate");
            let array = parser.data;
            assert.isUndefined(array[2]['Kate']);
            assert.equal(message2, "Removed correctly!");

            try {
                parser.removeEntry("baba");
                assert.fail()
            } catch (error) {
                assert.equal(error.message,"There is no such entry!");
            }

        })
    })
});