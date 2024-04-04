/* ESERCIZIO 1
 Scrivi un algoritmo per trovare il più grande tra due numeri interi.
*/

let x = 30;
let y = 20;

if(x < y){
  console.log("è minore")
}else if(x > y){
  console.log("è maggiore")
};

/* ESERCIZIO 2
  Scrivi un algoritmo che mostri "not equal" in console se un numero intero fornito è diverso da 5.
*/

let z = 5;
if(z === 5){
  console.log("è uguale a 5")
} else{
  console.log("non è uguale a 5")
};

/* ESERCIZIO 3
  Scrivi un algoritmo che mostri "divisibile per 5" in console se un numero fornito è perfettamente divisibile per 5 (suggerimento: usa l'operatore modulo)
*/

let d = 11;

if(d %5==0){
  console.log("divisibile per 5")
}else{
  console.log("non è divisibile per 5")
};

/* ESERCIZIO 4
  Scrivi un algoritmo per verificare che, dati due numeri interi, il valore di uno di essi sia 8 oppure se la loro addizione/sottrazione sia uguale a 8.
*/

let g =12;
let h = 4;

if(g === 8|h === 8| g + h == 8| g - h ==8){
  console.log("è verificato")
} else(
  console.log("Non è verificato")
);

/* ESERCIZIO 5
  Stai lavorando su un sito di e-commerce. Stai salvando il saldo totale del carrello dell'utente in una variabile "totalShoppingCart".
  C'è una promozione in corso: se il totale del carrello supera 50, l'utente ha diritto alla spedizione gratuita (altrimenti la spedizione ha un costo fisso pari a 10).
  Crea un algoritmo che determini l'ammontare totale che deve essere addebitato all'utente per il checkout.
*/

let totalShoppingCart = 50;
let spedizione = 10;
if(totalShoppingCart>50){
  console.log("hai accesso alla spedizione gratuita!")
} else if(totalShoppingCart<=50){
  console.log(('il totale (spedizione inclusa) è ')+ (totalShoppingCart + spedizione))
}

/* ESERCIZIO 6
  Stai lavorando su un sito di e-commerce. Oggi è il Black Friday e viene applicato il 20% su ogni prodotto.
  Modifica la risposta precedente includendo questa nuova promozione nell'algoritmo, determinando come prima se le spedizioni sono gratuite oppure no e e calcolando il totale.
*/

let totalShoppingCart2 = 20;
let spedizione2 = 10;
let sconto = (totalShoppingCart2*20)/100;

if(totalShoppingCart2 - sconto >50){
  console.log("Hai diritto alla spedizione gratuita")
} else if(totalShoppingCart2 - sconto <50){
  console.log(('il totale (spedizione inclusa) è ')+ (totalShoppingCart2 - sconto + spedizione2))
}

/* ESERCIZIO 7
  Crea tre variabili, e assegna un valore numerico a ciascuna di esse.
  Utilizzando un blocco condizionale, crea un algoritmo per ordinarle secondo il loro valore, dal più alto al più basso.
  Alla fine mostra il risultato in console.
*/
/* ESERCIZIO 8
  Crea un algoritmo per verificare che un valore fornito sia un numero oppure no (suggerimento: cerca su un motore di ricerca "typeof").
*/

let delta = 33;

if(typeof delta ==="number"){
  console.log("è un numero")
} else if (typeof delta != "number"){
  console.log("non è un numero")
}

/* ESERCIZIO 9
  Crea un algoritmo per controllare se un numero fornito sia pari o dispari (suggerimento: cerca l'operatore modulo su un motore di ricerca)
*/

let lambda = 5;

if(lambda %2 == 0){
  console.log("è pari")
}else{
  console.log("è dispari")
}


/* ESERCIZIO 10
  Modifica la logica del seguente algoritmo in modo che mostri in console il messaggio corretto in ogni circostanza.
  let val = 7
  if (val < 10) {
      console.log("Meno di 10");
    } else if (val < 5) {
      console.log("Meno di 5");
    } else {
      console.log("Uguale a 10 o maggiore");
    }
*/

let val = 10;
if(val < 5){
  console.log("Meno di 5")
} else if(val < 10){
  console.log("Meno di 10")
}else{
  console.log("Uguale a 10 o maggiore");
}

/* ESERCIZIO 11
  Fornito il seguente oggetto, scrivi del codice per aggiungere una proprietà "city", il cui valore sarà "Toronto".
*/

const me = {
  name: 'John',
  lastName: 'Doe',
  skills: ['javascript', 'html', 'css'],
}
me.city = "Toronto"
console.log(me)


/* ESERCIZIO 12
  Lavorando sempre sull'oggetto precedentemente fornito, scrivi del codice per rimuovere la proprietà "lastName".
*/
delete me.lastName;
console.log(me)

/* ESERCIZIO 13
  Lavorando sempre sull'oggetto precedentemente fornito, scrivi del codice per rimuovere l'ultimo elemento della proprietà "skills".
*/

me.skills.pop();
console.log(me)

/* ESERCIZIO 14
  Scrivi del codice per creare un array inizialmente vuoto. Riempilo successivamente con i numeri da 1 a 10.
*/

let numeri = [];
numeri.push("1");
numeri.push("2");
numeri.push("3");
numeri.push("4");
numeri.push("5");
numeri.push("6");
numeri.push("7");
numeri.push("8");
numeri.push("9");
numeri.push("10");
console.log(numeri)

/* ESERCIZIO 15
  Scrivi del codice per sostituire l'ultimo elemento dell'array, ovvero il valore 10, con il valore 100.
*/

numeri.pop();
numeri.push(100);
console.log(numeri)
