import React, { useState } from "react";
import Greeting from "./Greeting";
import LoginButton from "./LoginButton";
import LogoutButton from "./LogoutButton";
import "./LogInControl.css";

function LogInControl2() {
    const [isLoggedIn, setIsLoggedIn] = useState(false);

    const handleLoginClick = () => {
        setIsLoggedIn(true);
    };

    const handleLogoutClick = () => {
        setIsLoggedIn(false);
    };

    return (
        <div className="login-control">
            <Greeting isLoggedIn={isLoggedIn} />
            {isLoggedIn
                ? <LogoutButton onClick={handleLogoutClick} />
                : <LoginButton onClick={handleLoginClick} />
            }
        </div>
    );
}

export default LogInControl2;
