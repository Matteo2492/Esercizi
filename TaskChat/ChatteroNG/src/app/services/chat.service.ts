import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Risposta } from '../models/risposta';
import { Messaggio } from '../models/messaggio';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  constructor(
    private rottaAttiva: ActivatedRoute,
    private http: HttpClient,
    private router: Router
  ) {}

  stampaMessaggi(nomeChat: string): Observable<Risposta> {
    return this.http.get<Risposta>(
      'https://localhost:7260/Stanza/messaggi/' + nomeChat
    );
  }

  invio(contenuto: string,mittente: string,stanza: string): Observable<Risposta> {
    let m: Messaggio = new Messaggio();
    m.nomUte = mittente;
    m.sta = stanza;
    m.con = contenuto;

    let headerCustom = new HttpHeaders();
    headerCustom.set('Content-Type', 'application/json');

    return this.http.post<Risposta>('https://localhost:7260/Stanza/aggiungi_messaggio/', m, {
      headers: headerCustom,
    });
  }
}
