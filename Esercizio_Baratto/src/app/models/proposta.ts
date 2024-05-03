import { Oggetto } from './oggetto';
import { Persona } from './persona';
import { Transazione } from './transazione';

export class Proposta {
  [x: string]: any;
  private codice?: number | undefined;
  private offerente?: Persona | undefined;
  private aquirente?: Persona | undefined;
  private oggettoOff?: Oggetto | undefined;
  private oggettoAqu?: Oggetto | undefined;
  private stato: boolean = false;
  private transazione?: Transazione | undefined;

  constructor(
    cod?: number,
    off?: Persona,
    aqu?: Persona,
    oggO?: Oggetto,
    oggA?: Oggetto
  ) {
    this.codice = cod;
    this.offerente = off;
    this.aquirente = aqu;
    this.oggettoOff = oggO;
    this.oggettoAqu = oggA;
  }
  setTransazione(tr: Transazione) {
    this.transazione = tr;
  }
}
