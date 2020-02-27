class Company {
    constructor() {
        this.departments = [];
    }

    addEmployee(username, salary, position, department) {

        if (!username || !salary || !position || !department) {
            throw new Error("Invalid input!");
        }
        else if (salary < 0) {
            throw new Error("Invalid input!");
        }
        else {
            if (this.departments.some(x => x[department])) {
                let currDep = this.departments.find(x => x[department]);
                currDep[department].push({ username, position, salary });
            }
            else {
                let newDP = {};
                newDP[department] = [];
                newDP[department].push({ username, position, salary });
                this.departments.push(newDP);
            }
            return `New employee is hired. Name: ${username}. Position: ${position}`;
        }
  }

    bestDepartment() {

        for (const department of this.departments) {
            let employees = Object.values(department)[0];
            let sum = employees.reduce((acc, curr) => { return acc + curr.salary }, 0);
            let average = sum / employees.length;
            department['average'] = average.toFixed(2);
        }

        this.departments.sort((a, b) => { return b.average - a.average });

        let bestDep = this.departments[0];
        let toReturn = '';
        toReturn += `Best Department is: ${Object.keys(bestDep)[0]}\n`;
        toReturn += `Average salary: ${bestDep.average}\n`;
        let employees = Object.values(bestDep);

        for (const key in employees[0].sort((a, b) => {
            if (a.salary - b.salary != 0) {
                return b.salary - a.salary
            }
            else {
                return a.username.localeCompare(b.username);
            }
        })) {
            toReturn += `${employees[0][key].username} ${employees[0][key].salary} ${employees[0][key].position}\n`;
        }
        return toReturn.trim();
  }
}
let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.newDP())

