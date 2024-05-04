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
    return this.http.get<Risposta>(`${this.base_url}create_da/${nomeUtente}`);
  }
  recuperaStanzeP(nomeUtente : string|undefined) : Observable<Risposta> {
    return this.http.get<Risposta>(`${this.base_url}stanze_di/${nomeUtente}`);
  }
  recuperaStanzeNuove(nomeUtente : string|undefined) : Observable<Risposta> {
    return this.http.get<Risposta>(`${this.base_url}stanze_nuove/${nomeUtente}`);
  }
  creaStanza(sta:Stanza): Observable<Risposta> {
    let headerCustom = new HttpHeaders();
    headerCustom.set('Content-Type', 'application/json');

    return this.http.post<Risposta>(this.base_url +'creastanza', sta, {
      headers: headerCustom,
    });
  }
  aggiungiUtente(stanza:string,utente:string): Observable<Risposta>{
    let headerCustom = new HttpHeaders();
    headerCustom.set('Content-Type', 'application/json');

    return this.http.post<Risposta>(this.base_url +'aggiungipartecipante/'+stanza+"/"+utente, {
      headers: headerCustom,
    });
  }
  rimuoviUtente(stanza:string,utente:string): Observable<Risposta>{
    let headerCustom = new HttpHeaders();
    headerCustom.set('Content-Type', 'application/json');

    return this.http.put<Risposta>(this.base_url +'rimuovipartecipante/'+stanza+"/"+utente, {
      headers: headerCustom,
    });
  }
  creaGlobal(): Observable<Risposta> {
    let headerCustom = new HttpHeaders();
    headerCustom.set('Content-Type', 'application/json');

    return this.http.post<Risposta>(this.base_url +'global', {
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
