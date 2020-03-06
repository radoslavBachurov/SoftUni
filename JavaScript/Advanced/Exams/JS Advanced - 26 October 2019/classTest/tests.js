let SkiResort = require('./solution');
let assert = require('chai').assert;

describe('SkiResort testing behavior', function () {
    describe('constructor testing', () => {
        it('should instance new class correctly', () => {
            let newSki = new SkiResort('Balchik');
            assert.equal(newSki.name, 'Balchik');
            assert.equal(newSki.voters, 0);
            assert.equal(newSki.hotels.length, 0);
        })
    })

    describe('testing build() method', () => {
        it('if the beds are less than 1 error should be thrown', () => {
            let newSki = new SkiResort('Balchik');
            try {
                newSki.build('test', 0);
                assert.fail();
            } catch (error) {
                assert.equal(error.message, "Invalid input");
            }
        })

        it('if the name is empty string error should be thrown', () => {
            let newSki = new SkiResort('Balchik');
            try {
                newSki.build('', 1);
                assert.fail();
            } catch (error) {
                assert.equal(error.message, "Invalid input");
            }
        })

        it('if the input is correct a message should be returned', () => {
            let newSki = new SkiResort('Balchik');
            let message = newSki.build('test', 1);

            assert.equal(message, `Successfully built new hotel - test`);
            assert.equal(newSki.hotels.length, 1);
        })
    })

    describe('book method testing', () => {
        it('if name is empty throw an error', () => {
            let newSki = new SkiResort('Balchik');
            newSki.build('test', 1);
            try {
                newSki.book('', 1);
                assert.fail();
            } catch (error) {
                assert.equal(error.message, "Invalid input");
            }
        })

        it('if the beds are less than 1 error should be thrown', () => {
            let newSki = new SkiResort('Balchik');
            newSki.build('test', 1);
            try {
                newSki.book('test', 0);
                assert.fail();
            } catch (error) {
                assert.equal(error.message, "Invalid input");
            }
        })

        it('if no such a hotel throw error', () => {
            let newSki = new SkiResort('Balchik');
            try {
                newSki.book('test', 1);
                assert.fail();
            } catch (error) {
                assert.equal(error.message, "There is no such hotel");
            }
        })

        it('if there are not enought beds', () => {
            let newSki = new SkiResort('Balchik');
            newSki.build('test', 3)
            try {
                newSki.book('test', 5);
                assert.fail();
            } catch (error) {
                assert.equal(error.message, "There is no free space");
            }
        })

        it('if book is made a message should return and must decrease number of beds', () => {
            let newSki = new SkiResort('Balchik');
            newSki.build('test', 3);

            let message = newSki.book('test', 2);
            assert.equal(message, "Successfully booked");

            let currHotel = newSki.hotels.find(x => x.name === 'test');
            assert.equal(currHotel.beds, 1);
        })


    })

    describe('testing leave method', () => {
        it('if name is empty throw an error', () => {
            let newSki = new SkiResort('Balchik');
            newSki.build('test', 1);
            try {
                newSki.leave('', 1, 2);
                assert.fail();
            } catch (error) {
                assert.equal(error.message, "Invalid input");
            }
        })

        it('if the beds are less than 1 error should be thrown', () => {
            let newSki = new SkiResort('Balchik');
            newSki.build('test', 1);
            try {
                newSki.leave('test', 0, 2);
                assert.fail();
            } catch (error) {
                assert.equal(error.message, "Invalid input");
            }
        })

        it('if there is no such hotel error must be thrown', () => {
            let newSki = new SkiResort('Balchik');
            newSki.build('test', 1);
            try {
                newSki.leave('test1', 2, 2);
                assert.fail();
            } catch (error) {
                assert.equal(error.message, "There is no such hotel");
            }
        })

        it('must change properties beds,voter,points correctly', () => {
            let newSki = new SkiResort('Balchik');
            newSki.build('test', 6);
            newSki.book('test', 3);
            let message = newSki.leave('test', 2, 2);

            assert.equal(message, `2 people left test hotel`)

            let currHotel = newSki.hotels.find(x => x.name === 'test');
            assert.equal(newSki.voters, 2);
            assert.equal(currHotel.points, 4);
            assert.equal(currHotel.beds, 5);

        })
    })

    describe('average grade testing', () => {
        it('if no voters should return proper message', () => {
            let newSki = new SkiResort('balchik');
            let message = newSki.averageGrade();
            assert.equal(message, "No votes yet");
        })

        it('should return correct average grade', () => {
            let newSki = new SkiResort('Balchik');
            newSki.build('test', 6);
            newSki.book('test', 3);
            newSki.leave('test', 2, 2);

            newSki.build('test1', 10);
            newSki.book('test1', 7);
            newSki.leave('test1', 3, 5);

            assert.equal(newSki.averageGrade(), 'Average grade: 3.80');
        })
    })

    describe('bestHotel method test', () => {
        it('if voters are 0 should return message', () => {
            let newSki = new SkiResort('Balchik');
            assert.equal(newSki.bestHotel, "No votes yet");
        })

        it('if voters are >0 should return proper message', () => {
            let newSki = new SkiResort('Balchik');

            newSki.build('test', 6);
            newSki.book('test', 3);
            newSki.leave('test', 2, 2);

            newSki.build('test1', 10);
            newSki.book('test1', 7);
            newSki.leave('test1', 3, 5);

            let message = newSki.bestHotel;

            assert.equal(message, `Best hotel is test1 with grade 15. Available beds: 6`)
        })
    })
});
