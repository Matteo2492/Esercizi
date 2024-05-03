import { Proposta } from './proposta';

export class Transazione {
  private codice?: string | undefined;
  private proposta?: Proposta | undefined;
  private date: Date = new Date();

  constructor(cod?: string, prop?: Proposta) {
    this.codice = cod;
    this.proposta = prop;
  }
}
