import React from "react";
import Book from "./Book";
import "./BookList.css";

const books=[
    {
        title:"처음 만난 리액트",
        author:"김소플",
        coverImage:"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTrSyUogTE5VftecPt-Dx_gsycumNrkruXZ8bu7AM7Fl37JZapOheBf4aUO&s=10"
    },
    {
        title:"데이터베이스 실습",
        author:"박우창",
        coverImage:"https://i.namu.wiki/i/R27BGH3F33SRcF9M1UcW-WURx-Aj9-qktuwDO_Nv7tbYNW3wRXtLj-75oHyk_AjItsK66UrrDBmdIpaX4LnlBA.webp"
    },
    {
        title:"처음 만난 자바",
        author:"우재남",
        coverImage:"https://img.magnific.com/free-photo/vibrant-night-sky-with-stars-nebula-galaxy_146671-19230.jpg?semt=ais_hybrid&w=740&q=80"
    },
    {
        title:"처음 만난 리액트",
        author:"김소플",
        coverImage:"https://cdn.news.bbsi.co.kr/news/photo/202207/3074175_392766_040.png"
    },
    {
        title:"데이터베이스 실습",
        author:"박우창",
        coverImage:"https://img.magnific.com/free-photo/astral-concept-wallpaper_23-2150038875.jpg?semt=ais_hybrid&w=740&q=80"
    }
]

function BookList(){
    return(
        <div className={"bookListWrapper"}>
            {books.map((book) => {
                return (
                    <Book
                        title={book.title}
                        author={book.author}
                        coverImage={book.coverImage}
                    />
                );
            })}
        </div>
    );
}

export default BookList;