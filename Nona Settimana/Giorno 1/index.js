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
// Crea nuovo utente
let user = new User('Mario', 'Rossi');

// Ricarica il credito dell'utente
user.ricarica(20);

// Effettua una chiamata di 5 minuti
user.chiamata(5);

// Stampa il credito rimanente
console.log(user.chiamata404()); // Dovrebbe stampare 19

// Stampa il numero di minuti in chiamata
console.log(user.getNumeroChiamate()); // Dovrebbe stampare 5

// Azzera il numero di minuti in chiamata
user.azzeraChiamate();

// Stampa il numero di minuti in chiamata dopo l'azzeramento
console.log(user.getNumeroChiamate()); // Dovrebbe stampare 0