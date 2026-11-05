import React from "react";

function Prac() {
    const numbers = [1, 2, 3, 4, 5];
    const listItems = numbers.map((number) =>
        <li key={number}>{number}</li>
    );

    return <ul>{listItems}</ul>;
}

export default Prac;
