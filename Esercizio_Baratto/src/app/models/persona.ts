import { Oggetto } from './oggetto';
import { Proposta } from './proposta';

export class Persona {
  private codice: string | undefined;
  private nominativo: string | undefined;
  private listaOggetti: Oggetto[] = [];
  private listaProposte: Proposta[] = [];
  private idProposta: number = 0;

  constructor(cod?: string, nom?: string) {
    this.codice = cod;
    this.nominativo = nom;
  }
}
