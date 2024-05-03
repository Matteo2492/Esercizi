import { Injectable } from '@angular/core';
import { Oggetto } from '../models/oggetto';
import { Persona } from '../models/persona';
import { Proposta } from '../models/proposta';
import { PropostaServiceService } from './proposta-service.service';
@Injectable({
  providedIn: 'root',
})
export class PersonaServiceService {
  private listaOggetti: Oggetto[] = [];
  private listaProposte: Proposta[] = [];
  private idProposta: number = 0;

  constructor(private per:Persona) {
  }

  recuperaOggetti(): Oggetto[] {
    return this.listaOggetti;
  }

  aggiungiOggetto(objPro: Oggetto): boolean {
    if (objPro) {
      this.listaOggetti.push(objPro);
      return true;
    }

    return false;
  }

  rimuoviOggetto(codiceObj: string): boolean {
    for (let i = 0; i < this.listaOggetti.length; i++) {
      if (this.listaOggetti[i].getCodice() === codiceObj) {
        this.listaOggetti.splice(i, 1); // Rimuove l'oggetto dall'array
        return true;
      }
    }
    return false; // Nessun oggetto trovato con il codice specificato
  }

  propostaBaratto(
    vend: Persona,
    aqu: Persona,
    objO: Oggetto,
    ObjA: Oggetto
  ): void {
    let id: number = this.idProposta;
    let proposta: Proposta = new Proposta(id, vend, aqu, objO, ObjA);
    this.idProposta++;
    this.listaProposte.push(proposta);
  }

  gestisciRichiesta(prop: Proposta, risposta: boolean): boolean {
    if (risposta) {
      PropostaServiceService.registraTransazione();
      return risposta;
    } else {
      return false;
    }
  }
}
