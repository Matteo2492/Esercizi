import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Risposta } from '../models/risposta';
import { Utente } from '../models/utente';

@Injectable({
  providedIn: 'root'
})
export class UtenteService {

  base_url: string = 'https://localhost:7260/Utente/';

  constructor(private http: HttpClient) { }

  register(obj: Utente): Observable<Risposta> {
    let headerCustom = new HttpHeaders();
    headerCustom.set('Content-Type', 'application/json');

    return this.http.post<Risposta>(this.base_url + 'register', obj, {
      headers: headerCustom,
    });
  }
}
