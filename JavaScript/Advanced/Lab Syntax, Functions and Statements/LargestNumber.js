function solve(num1, num2, num3) {

    let max = Math.max(num1, Math.max(num2, num3));

    console.log(`The largest number is ${max}.`);
}

solve(5, -3, 16);