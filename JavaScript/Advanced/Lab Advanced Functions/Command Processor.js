function solve(){
    var person = (function () {

        let initialString = '';
    
        function append(input) {
            initialString += input;
        }
    
        function print() {
            console.log(initialString);
        }
    
        function removeStart(n) {
            initialString = initialString.substring(n)
        }
    
        function removeEnd(n) {
            initialString = initialString.substring(0, initialString.length-n)
        }
    
        return {
            append,
            print,
            removeStart,
            removeEnd
        }
    })();

    return person;
}






