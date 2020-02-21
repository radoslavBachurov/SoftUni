class CheckingAccount {
    _clientId;
    _email;
    _firstName;
    _lastName;

    constructor(clientId, email, firstName, lastName) {
        this.clientId = clientId;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    get clientId() {
        return this._clientId;
    }

    set clientId(value) {
        let type = typeof (value);
        let long = value.length;
        let number = Number(value);

        if (type == 'string' && long == 6 && typeof (number) == 'number') {
            this._clientId = value;
        }
        else {
            throw TypeError('Client ID must be a 6-digit number');
        }
    }

    get email() {
        return this._email;
    }

    set email(value) {
        if (/^[A-Za-z0-9]+@[A-Za-z.]+$/.test(value)) {
            this._email = value;
        }
        else {
            throw TypeError('Invalid e-mail');
        }
    }

    get firstName() {
        return this._firstName;
    }

    set firstName(value) {
        if (value.length >= 3 && value.length <= 20) {
            if (/^[A-Za-z]+$/.test(value)) {
                this._firstName = value;
            }
            else {
                throw TypeError(`First name must contain only Latin characters`);
            }
        }
        else {
            throw TypeError(`First name must be between 3 and 20 characters long`);
        }
    }

    get lastName() {
        return this._lastName;
    }

    set lastName(value) {
        if (value.length >= 3 && value.length <= 20) {
            if (/^[A-Za-z]+$/.test(value)) {
                this._lastName = value;
            }
            else {
                throw TypeError(`Last name must contain only Latin characters`);
            }
        }
        else {
            throw TypeError(`Last name must be between 3 and 20 characters long`);
        }
    }
}

let test = new CheckingAccount('123456', 'ivan@some.com', 'dasxsa', 'xaxa');

