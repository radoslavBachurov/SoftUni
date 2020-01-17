function solve(input) {
    const motorway = 130;
    const interstate = 90;
    const city = 50;
    const residential = 20;

    let speedLimit;
    switch (input[1]) {
        case 'city':
            speedLimit = city;
            break;
        case 'interstate':
            speedLimit = interstate;
            break;
        case 'residential':
            speedLimit = residential;
            break;
        case 'motorway':
            speedLimit = motorway;
            break;
        default:
            break;
    }

    let upToSpeed = Math.abs(speedLimit - input[0]);

    if (upToSpeed > 00 && upToSpeed <= 20) {

        console.log('speeding');

    } else if (upToSpeed > 20 && upToSpeed <= 40) {

        console.log('excessive speeding');

    } else if (upToSpeed > 40) {

        console.log('reckless driving');

    }
}

solve([120, 'interstate']);