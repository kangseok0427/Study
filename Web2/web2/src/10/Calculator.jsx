import { useState } from "react";
import TemperatureInput from "./TemperatureInput";

function toCelsius(fahrenheit) {
    return (fahrenheit - 32) * 5 / 9;
}

function toFahrenheit(celsius) {
    return celsius * 9 / 5 + 32;
}

function tryConvert(temperature, convert) {
    const input = parseFloat(temperature);
    if (Number.isNaN(input)) {
        return '';
    }
    return String(Math.round(convert(input) * 1000) / 1000);
}

function Calculator() {
    const [temperature, setTemperature] = useState('');
    const [scale, setScale] = useState('c');

    const handleCelsiusChange = (value) => {
        setTemperature(value);
        setScale('c');
    };

    const handleFahrenheitChange = (value) => {
        setTemperature(value);
        setScale('f');
    };

    const celsius = scale === 'f' ? tryConvert(temperature, toCelsius) : temperature;
    const fahrenheit = scale === 'c' ? tryConvert(temperature, toFahrenheit) : temperature;

    return (
        <div className="calculator">
            <TemperatureInput scale="c" temperature={celsius}
                onTemperatureChange={handleCelsiusChange} />
            <TemperatureInput scale="f" temperature={fahrenheit}
                onTemperatureChange={handleFahrenheitChange} />
            <p>{parseFloat(celsius) >= 100 ? '물이 끓습니다.' : '물이 끓지 않습니다.'}</p>
            <div className={parseFloat(celsius) >= 100 ? "water-cup boiling" : "water-cup"} aria-hidden="true">
                <div className="water">
                    <span className="bubble" />
                    <span className="bubble" />
                    <span className="bubble" />
                    <span className="bubble" />
                    <span className="bubble" />
                </div>
            </div>
        </div>
    );
}

export default Calculator;
