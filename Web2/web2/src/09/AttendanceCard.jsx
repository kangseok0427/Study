import React from "react";
import "./AttendanceCard.css";

function AttendanceCard(props) {
    const student = props.student;

    return (
        <article className="attendance-card">
            <img src={student.image} alt={student.name} />
            <div className="attendance-card-info">
                <h2>{student.name}</h2>
                <dl>
                    <dt>아이디</dt>
                    <dd>{student.id}</dd>
                    <dt>학번</dt>
                    <dd>{student.studentNumber}</dd>
                    <dt>학과</dt>
                    <dd>{student.department}</dd>
                </dl>
            </div>
        </article>
    );
}

export default AttendanceCard;
