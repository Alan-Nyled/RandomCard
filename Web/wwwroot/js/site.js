let btn = document.getElementById("draw-btn")
let text = document.getElementById("result")
let img = document.getElementById("img")

const getCard = () => {
    fetch("https://localhost:7164/")
        .then(response => response.json())
        .then(result => {
            let value
            translate[result.value] ? value = translate[result.value] : value = [result.value]
            text.innerText = `Du trak ${translate[result.type]} ${value}`
            img.src = `images/${value}-${translate[result.type]}.jpg`
        })
        .catch(error => console.error('Det gik ikke: ', error));
}

const translate = {
    Diamonds: "Ruder",
    Hearts: "Hjerter",
    Clubs: "Klør",
    Spades: "Spar",
    Joker: "En Joker",
    Queen: "Dame",
    King: "Konge",
    Jack: "Knægt",
    Ace: "Es"
}

btn.onclick = getCard
