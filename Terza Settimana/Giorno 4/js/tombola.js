const generateMainBoard = function () {
    var tabella= document.getElementById("mainboard");
    var numero = 1;
    for(i=0;i<9;i++){
        var riga= document.createElement("tr");
        for(d =0;d<10;d++){
            var cella= document.createElement("td");
            cella.textContent = numero;
            riga.appendChild(cella);
            numero++;
        }
        tabella.appendChild(riga)
    }
}

const fillArray = function generaArray () {
    var arrayNumeri = [];
    for (var i = 1; i <= 90; i++) {
        arrayNumeri.push(i);
    }
    return arrayNumeri;
}


const getRandomNum = function () {
    var arrayNumeri = fillArray();
    var numeroCasuale = arrayNumeri[Math.floor(Math.random() * arrayNumeri.length)];
   showNum(numeroCasuale);
   generateRandNumber(numeroCasuale);
}

const generateRandNumber = function (numero) {
    var celle= document.getElementsByTagName("td");
    for( h=0 ; h < celle.length;h++){
        if(parseInt(celle[h].textContent) === numero){
            celle[h].classList.add("sorted");
        }
    }
}
function showNum(numeroCasuale){
    var sortedNum = document.getElementById("sorted_num");
        sortedNum.textContent= "è uscito il numero: " + numeroCasuale;
    }
const generateUserBoards = function () {


}


window.onload = function() {
    generateMainBoard();
    var sortButton = document.getElementById("sort_btn");
    sortButton.addEventListener("click", getRandomNum);
};