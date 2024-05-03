import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Risposta } from '../components/risposta';
import { Observable } from 'rxjs';
import { Utente } from '../models/utente';

@Injectable({
  providedIn: 'root'
})
export class UtentiService {

  base_url: string = 'https://localhost:7198/Utente/';

  constructor(private http: HttpClient) {}

  register(obj:Utente): Observable<Risposta> {
    let headerCustom = new HttpHeaders();
    headerCustom.set('Content-Type', 'application/json');

    return this.http.post<Risposta>(this.base_url +'register', obj, {
      headers: headerCustom,
    });
  }
}
