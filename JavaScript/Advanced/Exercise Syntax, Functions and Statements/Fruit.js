function solve(fruit, weight, price) {
    let totalPrice = (weight / 1000) * price;
    console.log(`I need $${totalPrice.toFixed(2)} to buy ${(weight/1000).toFixed(2)} kilograms ${fruit}.`)
}

solve('orange', 2500, 1.80);