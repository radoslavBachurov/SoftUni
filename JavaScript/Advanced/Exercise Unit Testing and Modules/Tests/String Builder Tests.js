const StringBuilder = require('../String Builder');
let assert = require('chai').assert;

describe('stringBuilder functionality', () => {
    describe('Constructor is working correctly', () => {
        it('can be instanced with none input strings', () => {
            let str = new StringBuilder();
            assert.isTrue(str instanceof StringBuilder);
        })

        it('can be instanced with one input strings', () => {
            let str = new StringBuilder('test');
            assert.isTrue(str instanceof StringBuilder);
        })

        it('on initialising must throw error if input is not string', () => {
            function newClass() {
                let test = new StringBuilder(3)
            }
            assert.throws(newClass, Error);
        })

        it('must return empty string if nothing is added', () => {
            let test = new StringBuilder();
            assert.equal(test.toString(), '');
        })

        it('on initialising must throw accurate message error if input is not string', () => {
            try {
                let test = new StringBuilder(3)
            } catch (error) {
                let message = error.message;
                assert.equal(message, "Argument must be string");
            }

        })
    });

    describe('string builder append functionality', () => {
        it('append method must append to the end of the array', () => {
            let str = new StringBuilder('test');
            str.append('test2');

            assert.equal(str.toString(), 'testtest2');
        })

        it('append method must append to the end of the empty array', () => {
            let str = new StringBuilder();
            str.append('test2');

            assert.equal(str.toString(), 'test2');
        })
    });

    describe('string builder prepend functionality', () => {
        it('prepend method must prepend to the beggining of the array', () => {
            let str = new StringBuilder('test');
            str.prepend('test2');

            assert.equal(str.toString(), 'test2test');
        })

        it('prepend method must prepend to the beggining of the empty array', () => {
            let str = new StringBuilder();
            str.prepend('test2');

            assert.equal(str.toString(), 'test2');
        })

        it('prepend method two string accurate', () => {
            let str = new StringBuilder();
            str.prepend('test2');
            str.prepend('test1');

            assert.equal(str.toString(), 'test1test2');
        })
    });

    describe('string builder indexat functionality', () => {
        it('insertAt string with two string inside', () => {
            let str = new StringBuilder();
            str.append('test2');
            str.prepend('test1');
            str.insertAt('testMiddle', 5)
            assert.equal(str.toString(), 'test1testMiddletest2');
        })

        it('insertAt string with no strings inside', () => {
            let str = new StringBuilder();

            str.insertAt('testMiddle', 0)
            assert.equal(str.toString(), 'testMiddle');
        })

        it('insertAt string in the end', () => {
            let str = new StringBuilder();
            str.append('test2');
            str.prepend('test1');
            str.insertAt('testMiddle', 10)
            assert.equal(str.toString(), 'test1test2testMiddle');
        })
    })

    describe('string builder remove functionality', () => {
        it('remove string from the beggining', () => {
            let str = new StringBuilder();
            str.append('test2');
            str.prepend('test1');
            str.remove(0, 5)
            assert.equal(str.toString(), 'test2');
        })

        it('remove string from the middle', () => {
            let str = new StringBuilder();
            str.append('test2');
            str.prepend('test1');
            str.remove(4, 3)
            assert.equal(str.toString(), 'testst2');
        })

        it('remove all the string should return empty', () => {
            let str = new StringBuilder();
            str.append('test2');
            str.prepend('test1');
            str.remove(0, 10)
            assert.equal(str.toString(), '');
        })

    })

    describe('Check functionallity of StringBuilder class.', ()=>{
        it('should have the correct function properties',  ()=> {
            assert.equal(typeof(StringBuilder.prototype.append),'function');
            assert.equal(typeof(StringBuilder.prototype.prepend),'function');
            assert.equal(typeof(StringBuilder.prototype.insertAt),'function');
            assert.equal(typeof(StringBuilder.prototype.remove),'function');
            assert.equal(typeof(StringBuilder.prototype.toString),'function');

        });
    })

})