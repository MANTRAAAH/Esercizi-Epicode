
export interface Registration {
  nome: string | null;
  cognome: string | null;
  password: string | null;
  confermaPassword: string | null;
  genere: string | null;
  immagineProfilo?: File | null;
  biografia: string | null;
  username: string | null;
}
