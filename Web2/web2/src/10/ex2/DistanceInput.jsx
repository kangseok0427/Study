function DistanceInput(props) {
    const unitNames = { km: '킬로미터 (km)', mile: '마일 (mile)' };

    const handleChange = (event) => {
        props.onDistanceChange(event.target.value);
    };

    return (
        <fieldset>
            <legend>{unitNames[props.unit]}</legend>
            <input
                aria-label={unitNames[props.unit]}
                inputMode="decimal"
                value={props.distance}
                onChange={handleChange} />
        </fieldset>
    );
}

export default DistanceInput;
