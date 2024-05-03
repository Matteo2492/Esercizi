import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Risposta } from '../components/risposta';
import { Ristorante } from '../models/ristorante';

@Injectable({
  providedIn: 'root',
})
export class RistoranteService {
  base_url: string = 'https://localhost:7198/Ristorante/';

  constructor(private http: HttpClient) {}

  recuperaRistoranti() : Observable<Risposta> {
    return this.http.get<Risposta>(`${this.base_url}ristoranti`);
  }

  recuperaPiatti(varCodice:string) : Observable<Risposta> {
    return this.http.get<Risposta>(`https://localhost:7198/Ristorante/lista-menu/${varCodice}`);
  }
}
