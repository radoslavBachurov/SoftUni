function solve() {
    class Employee {
        constructor(name, age) {
            if (new.target === Employee) {
                throw new Error('Canot instantiate directly');
            }

            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = [];
        }

        work() {
            let currTask = this.tasks.shift();
            this.tasks.push(currTask);
            console.log(currTask);
        }

        collectSalary() {
            console.log(`${this.name} received ${this.salary} this month.`);
        }
    }

    class Junior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks = [`${this.name} is working on a simple task.`]
        }
    }

    class Senior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks = [`${this.name} is working on a complicated task.`,
            `${this.name} is taking time off work.`,
            `${this.name} is supervising junior workers.`];
        }
    }

    class Manager extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks = [`${this.name} scheduled a meeting.`,
            `${this.name} is preparing a quarterly report.`];
            this.dividend = 0;
        }

        collectSalary() {
            console.log(`${this.name} received ${this.salary + this.dividend} this month.`)
        }
    }

    return {
        Manager, Senior, Junior, Employee
    }
}