class Kitchen {
    constructor(budget) {
        this.budget = budget;
        this.menu = {};
        this.productsInStock = {};
        this.actionsHistory = [];

    }

    loadProducts(products) {
        for (const element of products) {
            let elements = element.split(' ').filter(x => x != '');
            let name = elements.slice(0, elements.length - 2).join(' ');
            let quantity = Number(elements[elements.length - 2]);
            let price = Number(elements[elements.length - 1]);

            if (this.budget >= price) {
                if (!this.productsInStock[name]) {
                    this.productsInStock[name] = 0;
                }
                this.productsInStock[name] += quantity;
                this.budget -= price;
                this.actionsHistory.push(`Successfully loaded ${quantity} ${name}`)
            }
            else {
                this.actionsHistory.push(`There was not enough money to load ${quantity} ${name}`)
            }
        }

        return this.actionsHistory.join('\n');
    }

    addToMenu(meal, products, price) {
        let listOfProducts = {};

        for (const product of products) {
            let productArr = product.split(' ').filter(x => x != '');
            let productName = productArr.slice(0, productArr.length - 1).join(' ');
            listOfProducts[productName] = Number(productArr[productArr.length - 1]);
        }

        if (!this.menu[meal]) {
            this.menu[meal] = { 'products': listOfProducts, 'price': Number(price) };
            return `Great idea! Now with the ${meal} we have ${Object.keys(this.menu).length} meals in the menu, other ideas?`
        }
        else {
            return `The ${meal} is already in our menu, try something different.`
        }
    }

    showTheMenu() {
        if (Object.keys(this.menu).length > 0) {
            let toReturn = '';
            for (const [key, value] of Object.entries(this.menu)) {
                toReturn += `${key} - $ ${this.menu[key].price}\n`
            }
            return toReturn;
        }
        else {
            return "Our menu is not ready yet, please come later...";
        }
    }

    makeTheOrder(meal) {
        if (!this.menu[meal]) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`
        }
        else {
            let productsNeeded = this.menu[meal].products;
            let haveProducts = true;

            for (const [key, value] of Object.entries(productsNeeded)) {
                if (!this.productsInStock[key] || this.productsInStock[key] < value) {
                    haveProducts = false;
                }
            }

            if (haveProducts) {
                for (const [key, value] of Object.entries(productsNeeded)) {
                    this.productsInStock[key] -= value;
                }
                this.budget += this.menu[meal].price;
                return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`
            }
            else {

                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`
            }

        }
    }
}

let kitchen = new Kitchen(3000);
console.log(kitchen.loadProducts(['Flour 10 5', 'Oil 20 10', 'Yeast 50 30', 'Salt 10 10', 'Sugar 500 1500', 'Tomato sauce 10 5 ', 'Pepperoni 4 3', 'Cheese 4 3']));
console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));

console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));

console.log(kitchen.showTheMenu());

console.log(kitchen.makeTheOrder('frozenYogurt'))

