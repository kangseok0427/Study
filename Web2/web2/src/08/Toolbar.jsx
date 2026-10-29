import React from "react";
import LoginButton from "./LoginButton";
import LogoutButton from "./LogoutButton";

function Toolbar(props) {
    return (
        <div className="toolbar">
            <span>{props.isLoggedIn ? '환영합니다!' : '로그인해 주세요.'}</span>
            {props.isLoggedIn
                ? <LogoutButton onClick={props.logoutClick} />
                : <LoginButton onClick={props.loginClick} />
            }
        </div>
    );
}

export default Toolbar;
