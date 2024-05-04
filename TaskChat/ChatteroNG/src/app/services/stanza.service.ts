import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Risposta } from '../models/risposta';
import { Stanza } from '../models/stanza';

@Injectable({
  providedIn: 'root'
})
export class StanzaService {

  base_url: string = 'https://localhost:7260/Stanza/';
 

  constructor(private http: HttpClient) {}

  recuperaStanzePerUtente(nomeUtente : string|undefined) : Observable<Risposta> {
    return this.http.get<Risposta>(`${this.base_url}create/${nomeUtente}`);
  }
  recuperaStanzeP(nomeUtente : string|undefined) : Observable<Risposta> {
    return this.http.get<Risposta>(`${this.base_url}partecipi/${nomeUtente}`);
  }
  creaStanza(sta:Stanza): Observable<Risposta> {
    let headerCustom = new HttpHeaders();
    headerCustom.set('Content-Type', 'application/json');

    return this.http.post<Risposta>(this.base_url +'creastanza', sta, {
      headers: headerCustom,
    });
  }
  eliminaStanza(nome: string): Observable<Risposta> {
    let headerCustom = new HttpHeaders().set('Content-Type', 'application/json');
    const url = `${this.base_url}elimina_stanza/${nome}`;
    return this.http.delete<Risposta>(url, {
      headers: headerCustom,
    });
  }
}
