import React from "react";
import "./Avatar.css";

function Avatar(props){
    return(
        <img
            src={props.user.avatarUrl}
        />
    );
}

export default Avatar;