import React from "react";
//import Button from "./Button";
import "./ConfirmDialog.css";

function ConfirmDialog(props) {
    return(
        <div className="div-bg-ivory">
            <p>을 확인한 후 눌러주세요.</p>
            <br/>
            <Button color="green">확인</Button>
            <Button color="red">취소</Button>
            <Button color="blue">초기화</Button>
        </div>
    )
}
export default ConfirmDialog;