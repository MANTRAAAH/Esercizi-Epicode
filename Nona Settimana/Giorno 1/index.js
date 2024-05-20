"use strict";
class User {
    constructor(nome, cognome) {
        this.credito = 0;
        this.numeroChiamate = 0;
        this.costoPerChiamata = 0.2; // Ad esempio, 0.2 euro al minuto
        this.nome = nome;
        this.cognome = cognome;
    }
    ricarica(importo) {
        this.credito += importo;
    }
    chiamata(minuti) {
        const costoChiamata = minuti * this.costoPerChiamata;
        if (this.credito >= costoChiamata) {
            this.credito -= costoChiamata;
            this.numeroChiamate += minuti;
        }
        else {
            console.log('Credito insufficiente per effettuare la chiamata');
        }
    }
    chiamata404() {
        return this.credito;
    }
    getNumeroChiamate() {
        return this.numeroChiamate;
    }
    azzeraChiamate() {
        this.numeroChiamate = 0;
    }
}
// Crea un nuovo utente
var utente = new User("Mario","Rossi");

// Ricarica il credito dell'utente
utente.ricarica(20);

// Effettua una chiamata di 5 minuti
utente.chiamata(19);

// Stampa il credito rimanente
console.log( "credito residuo =", utente.chiamata404()); // Dovrebbe stampare 19 (se il costo per minuto è 0.2)

// Stampa il numero di minuti in chiamata
console.log( "minuti in chiamata =", utente.getNumeroChiamate()); // Dovrebbe stampare 5

// Azzera il numero di chiamate
utente.azzeraChiamate();

// Stampa il numero di chiamate dopo l'azzeramento
console.log("ieri è iniziato un nuovo mese, perciò l'utente ha ora", utente.getNumeroChiamate() ,"minuti in chiamata"); // Dovrebbe stampare 0
