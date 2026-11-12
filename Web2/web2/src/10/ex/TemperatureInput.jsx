function TemperatureInput(props) {
    const scaleNames = { c: '섭씨', f: '화씨' };

    const handleChange = (event) => {
        props.onTemperatureChange(event.target.value);
    };

    return (
        <fieldset className="temperature-input">
            <legend>{scaleNames[props.scale]} 온도를 입력하세요:</legend>
            <input
                aria-label={scaleNames[props.scale] + ' 온도'}
                value={props.temperature}
                onChange={handleChange} />
        </fieldset>
    );
}

export default TemperatureInput;
