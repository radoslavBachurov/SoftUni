function solve(name, age, weight, height) {

    let bmi = Math.round(weight / Math.pow(height / 100, 2));
    let status = aquireStatus(bmi);
    let recommendation = status === 'obese' ? 'admission required' : undefined;

    let personalInfo = { age, weight, height };
    let object = {
        'name': name,
        'personalInfo': personalInfo,
        'BMI': bmi,
        'status': status,
        'recommendation': recommendation
    };

    return object;

    function aquireStatus(bmi) {
        if (bmi < 18.5) {
            return 'underweight';
        }
        else if (bmi < 25) {
            return 'normal';
        }
        else if (bmi < 30) {
            return 'overweight';
        }
        else {
            return 'obese';
        }
    }
}

solve();
console.log(solve('Ivan', 20, 55, 200));
//{ name: 'Honey Boo Boo', personalInfo: { age: 9, weight: 57, height: 137 }, BMI: 30, status: 'obese', recommendation: 'admission required' }