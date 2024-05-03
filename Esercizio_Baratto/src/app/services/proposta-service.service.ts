import { Injectable } from '@angular/core';
import { Proposta } from '../models/proposta';
import { Transazione } from '../models/transazione';
import { v4 as uuidv4 } from 'uuid';
@Injectable({
  providedIn: 'root',
})
export class PropostaServiceService {
  constructor() {}

  registraTransazione(prop: Proposta) {
    const uniqueCode: string = uuidv4();
    let transazione: Transazione = new Transazione(uniqueCode, prop);
    prop.setTransazione(transazione);
  }
}
