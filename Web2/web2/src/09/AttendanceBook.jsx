import React from "react";
import AttendanceCard from "./AttendanceCard";

const students = [
    {
        id: "기억속안개",
        name: "서",
        studentNumber: "20260001",
        department: "기억심리학과",
        image: process.env.PUBLIC_URL + "/images/morimens/xu.webp"
    },
    {
        id: "독의미궁",
        name: "아그리파",
        studentNumber: "20260002",
        department: "독성약학과",
        image: process.env.PUBLIC_URL + "/images/morimens/agrippa.webp"
    },
    {
        id: "사슬끊는검",
        name: "히로",
        studentNumber: "20260003",
        department: "전투체육학과",
        image: process.env.PUBLIC_URL + "/images/morimens/helot.webp"
    },
    {
        id: "모성의나무",
        name: "테이스",
        studentNumber: "20260004",
        department: "식물생명학과",
        image: process.env.PUBLIC_URL + "/images/morimens/thais.webp"
    }
];

function AttendanceBook(props) {
    return (
        <main className="attendance-page">
            <header>
                <h1>망각전야 출석부</h1>
            </header>
            <div className="attendance-cards">
                {students.map((student) => {
                    return <AttendanceCard key={student.id} student={student} />;
                })}
            </div>
        </main>
    );
}

export default AttendanceBook;
