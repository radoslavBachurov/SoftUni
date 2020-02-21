function solve(tickets, criteria) {

    let allTickets = [];

    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    let sortMethods = {
        'destination': (a, b) => { return a.destination.localeCompare(b.destination); },
        'price': (a, b) => { return a.price - b.price; },
        'status': (a, b) => { return a.status.localeCompare(b.status); }
    }


    for (const ticket of tickets) {
        let ticketInfo = ticket.split('|').filter(x => x != '');
        let singleTicket = new Ticket(ticketInfo[0], ticketInfo[1], ticketInfo[2]);
        allTickets.push(singleTicket);
    }

    allTickets.sort(sortMethods[criteria]);
    return allTickets;
}

solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'status'

);