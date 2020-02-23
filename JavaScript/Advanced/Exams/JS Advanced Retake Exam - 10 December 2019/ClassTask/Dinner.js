class ChristmasDinner {
    _budget;
    constructor(budget) {
        this.budget = budget;
        this.products = [];
        this.guests = {};
        this.dishes = [];
    }

    get budget() {
        return this._budget;
    }

    set budget(value) {
        if (value < 0) {
            throw new Error("The budget cannot be a negative number");
        }
        else {
            this._budget = value;
        }
    }

    shopping(product) {
        let name = product[0];
        let price = Number(product[1]);

        if (price > this._budget) {
            throw new Error("Not enough money to buy this product");
        }
        else {
            this.products.push(name);
            this.budget -= price;
            return `You have successfully bought ${name}!`;
        }
    }

    recipes(recipe) {
        let inputRecipe = recipe;
        let recipeName = inputRecipe[`recipeName`];
        let productsList = inputRecipe[`productsList`];

        let cook = true;

        for (const product of productsList) {
            if (!this.products.includes(product)) {
                cook = false;
            }
        }

        if (cook) {
            this.dishes.push(inputRecipe);
            return `${recipeName} has been successfully cooked!`;
        }
        else {
            throw new Error("We do not have this product");
        }
    }

    inviteGuests(name, dish) {
        let dishesNames = [];

        for (const dish of this.dishes) {
            dishesNames.push(Object.values(dish)[0]);
        }

        if (!dishesNames.includes(dish)) {
            throw new Error("We do not have this dish");
        }

        if (this.guests[name]) {
            throw new Error("This guest has already been invited");
        }
        else {
            this.guests[name] = dish;
            return `You have successfully invited ${name}!`
        }

    }

    showAttendance() {
        let toReturn = '';

        for (const key in this.guests) {

            let name = key;
            let dish = this.guests[key];
            let products = search(dish, this.dishes)

            toReturn += `${name} will eat ${dish}, which consists of ${products.join(', ')}\n`;
            
        }

        return toReturn.trim();

        function search(nameKey, myArray) {
            for (const dish of myArray) {
                if (dish['recipeName'] == nameKey) {
                    return dish['productsList'];
                }
            }
        }
    }


}

let dinner = new ChristmasDinner(300);

dinner.shopping(['Salt', 1]);
dinner.shopping(['Beans', 3]);
dinner.shopping(['Cabbage', 4]);
dinner.shopping(['Rice', 2]);
dinner.shopping(['Savory', 1]);
dinner.shopping(['Peppers', 1]);
dinner.shopping(['Fruits', 40]);
dinner.shopping(['Honey', 10]);

dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
});
dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
});
dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
});

dinner.inviteGuests('Ivan', 'Oshav');
dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
dinner.inviteGuests('Georgi', 'Peppers filled with beans');

console.log(dinner.showAttendance());
