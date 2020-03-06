// add 
// remove 
// print 
function solve(input) {
    let inputArr = input;

    function process() {
        this.str = [];
        this.add = (el) => { this.str.push(el) };
        this.remove = (el) => { this.str = this.str.filter(x => x !== el) };
        this.print = () => { console.log(this.str.join(',')) }
    }
    let processor = new process();

    inputArr.forEach(element => {
        let elArray = element.split(' ').filter(x => x != ' ');
        processor[elArray[0]](elArray[1]);
    });
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);
