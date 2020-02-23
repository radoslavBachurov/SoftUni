const ChristmasMovies = require('./02. Christmas Movies_Resources');
let assert = require('chai').assert;

describe('ChristmasMovies class test', function () {
    describe("Constructor Tests", function () {
        it("Instantiation with no parameters should create empty properties", function () {
            let newClass = new ChristmasMovies();
            assert.equal(newClass.actors.length, 0);
            assert.equal(newClass.movieCollection.length, 0);
            assert.equal((Object.keys(newClass.watched)).length, 0);
        });
    });

    describe('BuyMovie Method test', () => {
        it('if movie exist throw error with proper message', () => {
            let newClass = new ChristmasMovies();
            newClass.buyMovie('test', ['aa', 'bb']);

            try {
                newClass.buyMovie('test', ['aa', 'bb']);
                assert.fail();
            } catch (error) {
                assert.equal(error.message, `You already own test in your collection!`)
            }
        })

        it('should add unique actors', () => {
            let newClass = new ChristmasMovies();
            let message = newClass.buyMovie('test', ['aa', 'bb', 'bb', 'aa']);
            assert.equal(message, `You just got test to your collection in which aa, bb are taking part!`)
        })
    })

    describe('discardMovie method tests', () => {
        it('if i have a movie in my watched collection describe must delete it', () => {
            let newClass = new ChristmasMovies();
            newClass.buyMovie('test', ['aa', 'bb', 'bb', 'aa']);
            newClass.watchMovie('test');
            newClass.discardMovie('test');
            assert.isUndefined(newClass.watched['test']);
        });

        it('if i dont have a movie in my watched collection describe must throw error', () => {
            let newClass = new ChristmasMovies();
            newClass.buyMovie('test', ['aa', 'bb', 'bb', 'aa']);

            try {
                newClass.discardMovie('test');
                assert.fail();
            } catch (error) {
                assert.equal(error.message, `test is not watched!`)
            }
        });

        it('if movie is not in my collection discard should throw a message', () => {
            let newClass = new ChristmasMovies();

            try {
                newClass.discardMovie('test');
                assert.fail();
            } catch (error) {
                assert.equal(error.message, `test is not at your collection!`)
            }
        })

        it('if i have a movie in my collection discard must delete it', () => {
            let newClass = new ChristmasMovies();
            newClass.buyMovie('test', ['aa', 'bb', 'bb', 'aa']);
            newClass.watchMovie('test');
            newClass.discardMovie('test');
            assert.equal(newClass.movieCollection.findIndex(m => m.name === 'test'), -1);
        })

        it('if i have the movie discard must return proper message', () => {
            let newClass = new ChristmasMovies();
            newClass.buyMovie('test', ['aa', 'bb', 'bb', 'aa']);
            newClass.watchMovie('test');
            let message = newClass.discardMovie('test');

            assert.equal(message, `You just threw away test!`);
        })
    })

    describe('watchMovie method testing', () => {
        it('if i dont have the movie error should be thrown with message', () => {
            let newClass = new ChristmasMovies();

            try {
                newClass.watchMovie('test');
                assert.fail();
            } catch (error) {
                assert.equal(error.message, 'No such movie in your collection!');
            }
        })

        it('if movie is in the watchList count must increase', () => {
            let newClass = new ChristmasMovies();
            newClass.buyMovie('test');
            newClass.watchMovie('test');
            newClass.watchMovie('test');

            assert.equal(newClass.watched['test'], 2);
        })

        it('if movie is not in the watchList watch method must add it', () => {
            let newClass = new ChristmasMovies();
            newClass.buyMovie('test');
            newClass.watchMovie('test');

            assert.equal(newClass.watched['test'], 1);
        })
    })

    describe('favourite movie method test', () => {
        it('if i dont have watched movies error is thrown with message', () => {
            let newClass = new ChristmasMovies();

            try {
                newClass.favouriteMovie();
                assert.fail();
            } catch (error) {

                assert.equal(error.message, 'You have not watched a movie yet this year!')
            }
        })

        it('favorite method must return most watchable movie', () => {
            let newClass = new ChristmasMovies();
            newClass.buyMovie('test');
            newClass.buyMovie('test1');
            newClass.buyMovie('test2');
            newClass.watchMovie('test');
            newClass.watchMovie('test');
            newClass.watchMovie('test1');
            newClass.watchMovie('test2');

            assert.equal(newClass.favouriteMovie(), `Your favourite movie is test and you have watched it 2 times!`);
        })
    })

    describe('mostStarredActor method tests', () => {
        it('if no movies in my collection must throw error with message', () => {
            let newClass = new ChristmasMovies();

            try {
                newClass.mostStarredActor();
                assert.fail();
            } catch (error) {
                assert.equal(error.message, 'You have not watched a movie yet this year!');
            }
        })

        it('must return most starred actor', () => {
            let newClass = new ChristmasMovies();
            newClass.buyMovie('test', ['aa1', 'bb0', 'kk', 'bb0']);
            newClass.buyMovie('test2', ['bb4', 'bb1', 'aa1', 'uu']);
            newClass.buyMovie('test3', ['cc3', 'aa1', 'll', 'ee']);
            newClass.buyMovie('test4', ['jj1', 'bb7', 'bb0', 'qq']);

            let message = `The most starred actor is aa1 and starred in 3 movies!`

            assert.equal(newClass.mostStarredActor(),message);
        })
    })

});
