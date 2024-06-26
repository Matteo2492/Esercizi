import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EMPTY, Observable } from 'rxjs';
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
  ) { }

  stampaMessaggi(nomeChat: string): Observable<Risposta> {
    return this.http.get<Risposta>(
      'https://localhost:7260/Stanza/messaggi/' + nomeChat
    );
  }
  eliminaMsg(nome: string, ora: Date): Observable<Risposta> {
    let headerCustom = new HttpHeaders().set('Content-Type', 'application/json');
    const url = `https://localhost:7260/Messaggio/elimina_messaggio/` + nome + "/" + ora;
    return this.http.delete<Risposta>(url, {
      headers: headerCustom,
    });
  }
  invio(contenuto: string, mittente: string, stanza: string, immagine?: string | ArrayBuffer): Observable<Risposta> {
    if (!contenuto.trim() && !immagine) {
      return EMPTY;
    }
  
    let m: Messaggio = new Messaggio();
    m.nomUte = mittente;
    m.sta = stanza;
    m.con = contenuto;
    m.immagine = immagine; // Assicurati che immagine contenga i dati binari dell'immagine
  
    let headerCustom = new HttpHeaders().set('Content-Type', 'application/json');
  
    return this.http.post<Risposta>('https://localhost:7260/Stanza/aggiungi_messaggio/', m, {
      headers: headerCustom,
    });
  }
}
