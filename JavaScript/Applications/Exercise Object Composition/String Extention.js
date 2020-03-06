(function solve() {
    String.prototype.ensureStart = function (str) {
        if (!this.startsWith(str)) {
            let toReturn = this;
            toReturn = str + toReturn;
            return toReturn;
        }
        return this.valueOf();
    }

    String.prototype.ensureEnd = function (str) {
        if (!this.endsWith(str)) {
            let toReturn = this;
            toReturn += str;
            return toReturn;
        }
        return this.valueOf();
    }


    String.prototype.isEmpty = function () {
        if (this.length == 0) {
            return true;
        }

        return false;
    }

    String.prototype.truncate = function (n) {
        if (this.length <= n) {
            return this.valueOf();
        }
        if (n < 4) {
            let toReturn = ".".repeat(n)
            return toReturn;
        }
        else {
            let strArr = this.split(' ').filter(x => x != ' ');
            if (strArr.length == 1) {
                let charArr = strArr[0].split('');
                charArr = charArr.splice(0, n - 3);
                charArr = charArr.join(' ') + '...';
                return charArr;
            }
            else {
                let sumLenght = 0;
                let str = strArr.join(' ');
                while (str.length + 3 > n) {
                    str = str.split(' ');
                    str.pop();
                    str = str.join(' ');
                }

                return (str + '...');
            }
        }
    }

    String.format = function (input) {
        let args = Array.from(arguments);
        let str = args.shift();

        const found = str.match(/{[0-9]}/g);
        for (let index = 0; index < args.length; index++) {
            str = str.replace(found[index], args[index]);
        }
        return str;
    }
}())

var testString = 'themandatorytest quick brown fox jumps over the lazy dog';
testString = testString.truncate(13)
console.log(testString);

