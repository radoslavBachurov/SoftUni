function solve(data, criteria) {
    let dataArr = JSON.parse(data);
    let criteriaArr = criteria.split('-').map(x => x.trim());
    let id = 0;

    if (criteriaArr.length == 1) {
        for (const person of dataArr) {
            printing(person,id);
            id++;
        }
    }
    else {
        let property = criteriaArr[0];
        let value = criteriaArr[1];

        for (const person of dataArr) {
            if (person[property] == value) {
                printing(person,id);
                id++;
            }
        }
    }

    function printing(person,id) {
        console.log(`${id}. ${person['first_name']} ${person['last_name']} - ${person['email']}`);
    }

}

//1. Kizzee Jost - kjost1@forbes.com

solve(`[{
    "id": "1",
    "first_name": "Ardine",
    "last_name": "Bassam",
    "email": "abassam0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Jost",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  },  
{
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }]`,
    'gender-Female'
);