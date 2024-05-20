interface Smartphone {
    credito: number;
    numeroChiamate: number;
    ricarica: (importo: number) => void;
    chiamata: (minuti: number) => void;
    chiamata404: () => number;
    getNumeroChiamate: () => number;
    azzeraChiamate: () => void;
}

class User implements Smartphone {
    nome: string;
    cognome: string;
    credito: number = 0;
    numeroChiamate: number = 0;
    costoPerChiamata: number = 0.2; // Ad esempio, 0.2 euro al minuto

    constructor(nome: string, cognome: string) {
        this.nome = nome;
        this.cognome = cognome;
    }

    ricarica(importo: number) {
        this.credito += importo;
    }

chiamata(minuti: number) {
    const costoChiamata = minuti * this.costoPerChiamata;
    if (this.credito >= costoChiamata) {
        this.credito -= costoChiamata;
        this.numeroChiamate += minuti;
    } else {
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
