/* ESERCIZIO 4 (forEach)
  Scrivi una funzione per sommare i numeri contenuti in un array
*/




function somma(oggetto){
    let totale = 0;
    for (let delta of oggetto){
      totale += delta;
    }
    return totale;
  }