import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RisToken } from '../components/ris-token';
import { Risposta } from '../components/risposta';
import { Utente } from '../models/utente';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient) {}

  login(obj: Utente): Observable<RisToken> {
    let headerCustom = new HttpHeaders();
    headerCustom.set('Content-Type', 'application/json');
    return this.http.post<any>('https://localhost:7198/Utente/login', obj, {
      headers: headerCustom,
    });
  }
}
