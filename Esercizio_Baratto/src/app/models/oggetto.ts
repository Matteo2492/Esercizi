import { Persona } from './persona';

export class Oggetto {
  private codice: string | undefined;
  private nome: string | undefined;
  private descrizione: string | undefined;

  constructor(codice?: string, nome?: string, descrizione?: string) {
    this.codice = codice;
    this.nome = nome;
    this.descrizione = descrizione;
  }
  getCodice(): string {
    if (this.codice) return this.codice;
    else {
      return "Codice dell'oggetto non inserito";
    }
  }
}
