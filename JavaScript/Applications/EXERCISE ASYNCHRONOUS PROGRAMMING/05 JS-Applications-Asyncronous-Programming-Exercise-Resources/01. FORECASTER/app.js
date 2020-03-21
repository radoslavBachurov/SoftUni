function attachEvents() {

    let btnSubmit = document.getElementById('submit');
    let inputBox = document.getElementById('location');
    let forecast = document.getElementById('forecast');

    forecast.style.display = 'block';

    let currentWeather = document.getElementById("current");
    let upcomingWeather = document.getElementById("upcoming");
    let currentWeatherMessage = currentWeather.children[0];

    currentWeather.style.display = 'none';
    upcomingWeather.style.display = 'none';


    btnSubmit.addEventListener('click', getWeather)

    async function getWeather() {

        try {
            if (upcomingWeather.children.length > 1) {
                upcomingWeather.children[1].remove();
                currentWeather.children[1].remove();
            }

            let url = "https://judgetests.firebaseio.com/locations.json";

            let responce = await fetch(url);
            if (responce.status >= 400) {
                throw new Error();
            }
            let data = await responce.json();
            let code = '';

            for (const iterator of data) {
                if (iterator.name == inputBox.value) {
                    code = iterator.code;
                }
            }

            if (code === '') {
                throw new Error();
            }

            let currURl = `https://judgetests.firebaseio.com/forecast/today/${code}.json`;
            let currResponce = await fetch(currURl);
            if (currResponce.status >= 400) {
                throw new Error();
            }
            let currData = await currResponce.json();

            let threeDayURl = `https://judgetests.firebaseio.com/forecast/upcoming/${code}.json`;
            let threeDayResponce = await fetch(threeDayURl);
            if (threeDayResponce.status >= 400) {
                throw new Error();
            }
            let threeDayData = await threeDayResponce.json();

            let location = currData.name;

            let currLowTemp = currData.forecast.low;
            let currHighTemp = currData.forecast.high;
            let currCondition = currData.forecast.condition;

            currConditionInfo(currLowTemp, currHighTemp, currCondition, location);

            let newEl = document.createElement('div');
            newEl.className = "forecast-info";

            for (let index = 0; index < threeDayData.forecast.length; index++) {
                let threeLowTemp = threeDayData.forecast[index].low;
                let threeHighTemp = threeDayData.forecast[index].high;
                let threeCondition = threeDayData.forecast[index].condition;
                newEl.appendChild(upcoingConditionInfo(threeLowTemp, threeHighTemp, threeCondition));
            }

            upcomingWeather.appendChild(newEl);
            currentWeather.style.display = 'block';
            upcomingWeather.style.display = 'block';
            currentWeatherMessage.textContent = `Current conditions`;
            inputBox.value = '';

        } catch (error) {
            currentWeather.style.display = 'block';
            upcomingWeather.style.display = 'none';
            currentWeatherMessage.textContent = `Error`;
            inputBox.value = '';
        }
    }

    function getConditionSymbol(input) {
        if (input === 'Sunny') {
            return "☀";
        }
        else if (input === 'Partly sunny') {
            return "⛅";
        }
        else if (input === 'Overcast') {
            return "☁";
        }
        else if (input === 'Rain') {
            return "☂";
        }

    }

    function currConditionInfo(lowTemp, highTemp, condition, location) {
        let newEl = document.createElement('div');
        newEl.className = "forecasts";

        let mainSpan = document.createElement('span');
        mainSpan.className = "condition symbol";
        mainSpan.textContent = getConditionSymbol(condition);

        let spanOne = document.createElement('span');
        spanOne.className = "condition";

        let locationSpan = document.createElement('span');
        locationSpan.className = "forecast-data";
        locationSpan.textContent = location;

        let temperatureSpan = document.createElement('span');
        temperatureSpan.className = "forecast-data";
        temperatureSpan.textContent = `${lowTemp}°/${highTemp}°`;

        let weatherSpan = document.createElement('span');
        weatherSpan.className = "forecast-data";
        weatherSpan.textContent = condition;

        spanOne.appendChild(locationSpan);
        spanOne.appendChild(temperatureSpan);
        spanOne.appendChild(weatherSpan);

        newEl.appendChild(mainSpan);
        newEl.appendChild(spanOne)
        currentWeather.appendChild(newEl);
    }

    function upcoingConditionInfo(lowTemp, highTemp, condition) {

        let mainSpan = document.createElement('span');
        mainSpan.className = "upcoming";

        let spanOne = document.createElement('span');
        spanOne.className = "symbol";
        spanOne.textContent = getConditionSymbol(condition);

        let temperatureSpan = document.createElement('span');
        temperatureSpan.className = "forecast-data";
        temperatureSpan.textContent = `${lowTemp}°/${highTemp}°`;

        let weatherSpan = document.createElement('span');
        weatherSpan.className = "forecast-data";
        weatherSpan.textContent = condition;

        mainSpan.appendChild(spanOne);
        mainSpan.appendChild(temperatureSpan);
        mainSpan.appendChild(weatherSpan);

        return mainSpan;
    }
}

attachEvents();