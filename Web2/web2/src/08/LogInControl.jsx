import React, { useState } from "react";
import Greeting from "./Greeting";
import LoginButton from "./LoginButton";
import LogoutButton from "./LogoutButton";
import "./LogInControl.css";

function LogInControl() {
    const [isLoggedIn, setIsLoggedIn] = useState(false);

    const logInClickListener = () => {
        setIsLoggedIn(true);
    };

    const logOutClickListener = () => {
        setIsLoggedIn(false);
    };

    let button;

    if (isLoggedIn) {
        button = <LogoutButton onClick={logOutClickListener} />;
    } else {
        button = <LoginButton onClick={logInClickListener} />;
    }

    return (
        <div className="login-control">
            <Greeting isLoggedIn={isLoggedIn} />
            {button}
        </div>
    );
}

export default LogInControl;
