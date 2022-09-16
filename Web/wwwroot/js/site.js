let btn = document.getElementById("draw-btn")
let text = document.getElementById("result")
let placeholder = document.getElementById("placeholder")
let check = document.getElementById("multiple")

const insertCardImage = src => {
    let img = new Image
    img.style.width = "200px"
    if (!check.checked) {
        placeholder.innerHTML = ""
        img.src = `images/${src.value}-${src.type}.jpg`
    }
    else {
        img.style.width = "100px"
        img.src = `images/${src.value}-${src.type}.jpg`
    }
    placeholder.append(img)
}

const reset = () => fetch("https://localhost:7164/reset")

const getCard = () => {
    let url = "https://localhost:7164/onecard"
    if (check.checked === true)
        url = "https://localhost:7164/multiplecards"
    fetch(url)
        .then(response => response.json())
        .then(result => {
            text.innerText = `Du trak ${result.type} ${result.value}`
            if(result.random != 0)
                insertCardImage(result)
        })
        .catch(error => console.error('Det gik ikke efter planen: ', error));
    btn.blur()
}


check.oninput = () => {
    placeholder.innerHTML = ""
    text.innerText = ""
    reset()
}
btn.onclick = getCard
