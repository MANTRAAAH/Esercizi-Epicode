
const removeButton = document.getElementById("remove_btn");
const saveButton = document.getElementById("save_btn");
const cleanButton = document.getElementById("clean_btn");
const displayButton = document.getElementById("display_btn");
const input = document.getElementById("name");
const displayDiv = document.getElementById("display_area");

const save = function () {
    const inputText = input.value;
    localStorage.setItem("name", inputText);
    console.log("Testo salvato", inputText);
};

const display_text = function () {
    const testoDaMostrare = localStorage.getItem("name");
    displayDiv.innerHTML = testoDaMostrare;
};

const pulisci = function () {
    const daPulire = document.getElementById("name");
    daPulire.value = "";
    console.log("Testo rimosso");
}

const remove = function () {
    localStorage.removeItem("name");
    console.log("Nome rimosso");
    display_text();
};

cleanButton.addEventListener("click", pulisci)

saveButton.addEventListener("click", save)

removeButton.addEventListener("click", remove);

displayButton.addEventListener("click", display_text);




//esercizio 2

function updateCounter() {
    if (sessionStorage.getItem('counter')) {
        let counter = parseInt(sessionStorage.getItem('counter'));
        counter++;
        sessionStorage.setItem('counter', counter);
        document.getElementById('counter').innerText = counter + " secondi";
    } else {
        sessionStorage.setItem('counter', 1);
        document.getElementById('counter').innerText = 1 + " secondo";
    }
}

function startCounter() {
    setInterval(updateCounter, 1000);
}

window.onload = startCounter;
