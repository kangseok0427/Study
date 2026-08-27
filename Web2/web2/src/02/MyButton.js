function MyButton() {

    const [isClicked, setClicked] = React.useState(false);

    return React.createElement(
        "button",
        {
            onClick: () => setClicked(!isClicked)
        },
        isClicked ? "Clicked!" : "Click me!"
    );
}

const donContainer = document.querySelector("#root");
//const donContainer:Element = document.querySelector("#root");

const root = ReactDOM.createRoot(donContainer);
root.render(React.createElement(MyButton));