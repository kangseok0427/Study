import React from "react";

function Mailbox(props) {
    const unreadMessages = 2;

    return (
        <div>
            <h1>안녕하세요!</h1>
            {unreadMessages > 0 &&
                <h2>
                    현재 {unreadMessages}개의 읽지 않은 메시지가 있습니다.
                </h2>
            }
        </div>
    );
}

export default Mailbox;
