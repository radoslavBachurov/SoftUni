function solve(array, criteria) {
    let inputArr = array;
    let inputCriteria = criteria;

    let sortMethod = {
       'asc':(s) => s.sort((a,b)=>a-b),
       'desc':(s) => s.sort((a,b)=>b-a)
    }

    return sortMethod[criteria](array);
}

console.log(solve([14, 7, 17, 6, 8], 'asc'));