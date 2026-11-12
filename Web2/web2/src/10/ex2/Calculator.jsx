import { useState } from "react";
import DistanceInput from "./DistanceInput";
import "./Calculator.css";

function Calculator() {
    const [distance, setDistance] = useState('');
    const [unit, setUnit] = useState('km');

    const handleKilometerChange = (value) => {
        setDistance(value);
        setUnit('km');
    };

    const handleMileChange = (value) => {
        setDistance(value);
        setUnit('mile');
    };

    const kilometers = unit === 'mile' ? tryConvert(distance, toKilometers) : distance;
    const miles = unit === 'km' ? tryConvert(distance, toMiles) : distance;

    return (
        <div className="distance-calculator">
            <h2>킬로미터 마일 변환</h2>
            <DistanceInput unit="km" distance={kilometers}
                onDistanceChange={handleKilometerChange} />
            <DistanceInput unit="mile" distance={miles}
                onDistanceChange={handleMileChange} />
            <p>1마일 = 1.609344킬로미터</p>
        </div>
    );
}

function toKilometers(miles) {
    return miles * 1.609344;
}

function toMiles(kilometers) {
    return kilometers / 1.609344;
}

function tryConvert(distance, convert) {
    const input = parseFloat(distance);
    if (Number.isNaN(input)) {
        return '';
    }
    return String(Math.round(convert(input) * 1000000) / 1000000);
}

export default Calculator;
