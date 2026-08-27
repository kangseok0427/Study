import React from "react";
import Book from "./Book";

function Library(){
    return(
        <div>
            <Book name="처음 만난 Java" numOfPage={300}></Book>
            <Book name="처음 만난 Python" numOfPage={400}></Book>
            <Book name="처음 만난 JavaScript" numOfPage={500}></Book>
        </div>
    );
}

export default Library;