import React from "react";
import UserInfo from "./UserInfo";
import "./UserInfoList.css";

const users = [
    {
        name : "Jang Wonyoung",
        avatarUrl : "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ6lMJjQfJBj9eNJ0ncstK54goX4hZC9TJNOGPdxz6eMQ&s=10",
        comment:"Positive mindset, lucky vibe~"
    },
    {
        name : "안유진",
        avatarUrl : "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRwTftGMkX8kJ9laq7gMX3XLaGbh5TfHAX5rmvjKUZhow&s=10",
        comment:"레전드 바이브코딩 날먹인간"
    },
    {
        name : "박리즈",
        avatarUrl : "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRFrFVLfcD2IF87DgGFR5UU7yGadCUiGPYi-ftZHbulUg&s=10",
        comment:"AI 안쓰는 레전드 구식인간"
    }
];

function UserInfoList(){
    const currentDate = new Date();
    return(
        <div>
            {
                users.map((user) => {
                    return(
                        <div className={"comment"}>
                            <UserInfo user={user}/>
                            <div className={"comment-text"}>
                                {user.comment}
                            </div>
                            <div className={"comment-date"}>
                                {currentDate.toDateString()}
                            </div>
                        </div>
                    );
                })
            }


        </div>
    );
}

export default UserInfoList;
