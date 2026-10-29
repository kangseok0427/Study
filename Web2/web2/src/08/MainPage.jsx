import React, { useState } from "react";
import WarningBanner from "./WarningBanner";
import "./LogInControl.css";

function MainPage() {
    const [showWarning, setShowWarning] = useState(false);

    const handleToggleClick = () => {
        setShowWarning(prevShowWarning => !prevShowWarning);
    };

    return (
        <div className="login-control">
            <WarningBanner warning={showWarning} />
            <button onClick={handleToggleClick}>
                {showWarning ? '감추기' : '보이기'}
            </button>
        </div>
    );
}

export default MainPage;
