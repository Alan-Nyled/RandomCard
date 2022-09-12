let btn = document.getElementById("draw-btn")
let text = document.getElementById("result")
let img = document.getElementById("img")

const getCard = () => {
    fetch("https://localhost:7164/")
        .then(response => response.json())
        .then(result => {
            text.innerText = `Du trak ${result.type} ${result.value}`
            img.src = `images/${result.value}-${result.type}.jpg`
        })
        .catch(error => console.error('Det gik ikke efter planen: ', error));
    btn.blur()
}

btn.onclick = getCard
