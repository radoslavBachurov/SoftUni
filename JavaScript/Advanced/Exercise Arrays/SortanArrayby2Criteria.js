function solve(input) {
    let inputArr = input;

    let sortedArr = inputArr.sort(sorting);

    function sorting(a, b) {
        if (a.length < b.length) {
            return -1;
        }
        else if (a.length > b.length) {
            return 1;
        }
        else {
            return a.localeCompare(b);
        }
    }

    return sortedArr.join('\n');
}

console.log(solve(['alpha', 
'beta', 
'gamma']
));