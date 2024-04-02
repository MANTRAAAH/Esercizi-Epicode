/*
REGOLE
- Tutte le risposte devono essere scritte in JavaScript
- Puoi usare Google / StackOverflow ma solo quanto ritieni di aver bisogno di qualcosa che non è stato spiegato a lezione
- Puoi testare il tuo codice in un file separato, o de-commentando un esercizio alla volta
- Per visualizzare l'output, lancia il file HTML a cui è collegato e apri la console dagli strumenti di sviluppo del browser. 
- Utilizza dei console.log() per testare le tue variabili e/o i risultati delle espressioni che stai creando.
*/

/* ESERCIZIO 1
 Elenca e descrivi i principali datatype in JavaScript. Prova a spiegarli come se volessi farli comprendere a un bambino.
*/

/*
 I principali datatype sono:
 TIPO DI DATI STRINGA: è una sequenza di lettere racchiusa in virgolette o doppie virgolette, è indifferente, l'importante è che si utilizzino in una stringa lo stesso tipo di virgolette sia all'inizio che alla fine di essa.
 Esiste un tipo speciale di stringa, chiamata stringa vuota ed è scritta lasciando, appunto, vuote le virgolette. Per scrivere i caratteri speciali si utilizza la barra rovesciata (\ comunemente detta carattere di escaping) e
  ci permette di trasformare un carattere che normalmente potrebbe dare problemi al codice, rendendolo privo di funzione.
  
  TIPO DI DATI NUMERI: i dati numerici possono essere interi o decimali(102 o 10.2), senza alcuna differenza, ne basta specificare la virgola e possono essere positivi (10) e/o negativi (-10). Esiste un carattere (NaN,letteralmente Not A Number) che definisce un valore numerico non definito.

  TIPO DI DATI NULL: definisce un valore che non rientri nei tipi di dati del linguaggio di javascript.

  TIPO DI DATI UNDEFINED: definisce un valore che non esiste, per esempio quando non ne assegnamo uno ad una variabile, nemmeno null.
  
  TIPO DI DATI BOOLEANO: ha solo due valori true(vero)|false(falso).
*/


/* ESERCIZIO 2
 Crea una variable chiamata "myName" e assegna ad essa il tuo nome, sotto forma di stringa.
*/

var myName = "Antonio";   //<- ho dato alla variabile var il mio nome
console.log('il mio nome è ' +myName);     //<- ho dato un'istruzione console log in modo da stampare nella console la variabile myName


/* ESERCIZIO 3
 Scrivi il codice necessario ad effettuare un addizione (una somma) dei numeri 12 e 20.
*/

  
  var numero1 = 12;  //<- prima variabile
  var numero2 = 20;  //<- seconda variabile
  var somma = numero1 + numero2;

  console.log('Il totale è '+somma);    //<- somma delle due variabili in console.



/* ESERCIZIO 4
 Crea una variable di nome "x" e assegna ad essa il numero 12.
 */


var x = 12; 




/* ESERCIZIO 5
  Riassegna un nuovo valore alla variabile "myName" già esistente: il tuo cognome.
  Dimostra l'impossibilità di riassegnare un valore ad una variabile dichiarata con il costrutto const.
*/

/*
const myName = "Annunziata";     //<- La const myName è Annunziata
myName = "Antonio";             // <- decommentando si evidenzia che c'è un errore in console che fa notare l'impossibilità di dare alla stringa myName il valore "Antonio"
*/

/* ESERCIZIO 6
 Esegui una sottrazione tra i numeri 4 e la variable "x" appena dichiarata (che contiene il numero 12).
*/


y = x - 4;    //<- istruzione per la sottrazione
console.log(x - 4)   //<- log per la verifica della riuscita dell'istruzione




/* ESERCIZIO 7
 Crea due variabili: "name1" e "name2". Assegna a name1 la stringa "john", e assegna a name2 la stringa "John" (con la J maiuscola!).
 Verifica che name1 sia diversa da name2 (suggerimento: è la stessa cosa di verificare che la loro uguaglianza sia falsa).
 EXTRA: verifica che la loro uguaglianza diventi true se entrambe vengono trasformate in lowercase (senza cambiare il valore di name2!).
*/

var name1 = 'john';
var name2 = 'John';
name1==name2 ?  console.log("sono uguali") : console.log("sono diversi");
name1==name2.toLowerCase() ?  console.log("sono uguali") : console.log("sono diversi");