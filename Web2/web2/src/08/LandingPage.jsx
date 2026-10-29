import React, { useState } from "react";
import Toolbar from "./Toolbar";
import dog from "./dog.jpg";
import "./LogInControl.css";
import "./LandingPage.css";

function LandingPage() {
    const [isLoggedIn, setIsLoggedIn] = useState(false);

    const loginClick = () => {
        setIsLoggedIn(true);
    };

    const logoutClick = () => {
        setIsLoggedIn(false);
    };

    return (
        <div className="login-control landing-page">
            <Toolbar isLoggedIn={isLoggedIn} loginClick={loginClick} logoutClick={logoutClick} />
            <div className="landing-content">
                <p>9장 조건부 렌더링 실습 화면입니다.</p>
                <img src={dog} alt="래브라도 강아지" />
            </div>
        </div>
    );
}

export default LandingPage;
