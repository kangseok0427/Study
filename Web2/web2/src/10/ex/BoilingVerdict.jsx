function BoilingVerdict(props) {
    const isBoiling = props.celsius >= 100;

    return (
        <>
            <p>{isBoiling ? '물이 끓습니다.' : '물이 끓지 않습니다.'}</p>
            <div className={isBoiling ? "water-cup boiling" : "water-cup"} aria-hidden="true">
                <div className="water">
                    <span className="bubble" />
                    <span className="bubble" />
                    <span className="bubble" />
                    <span className="bubble" />
                    <span className="bubble" />
                </div>
            </div>
        </>
    );
}

export default BoilingVerdict;
