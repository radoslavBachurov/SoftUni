function arrayMap(nums, func) {
    let toReturn = nums.reduce((acc, curr) => {
        acc.push(func(curr));
        return acc;
    }, [])

    return toReturn;
}

let nums = [1, 2, 3, 4, 5];
console.log(arrayMap(nums, (item) => item * 2));
