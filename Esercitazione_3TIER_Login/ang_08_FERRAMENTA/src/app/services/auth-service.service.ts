import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RisToken } from '../models/ris-token';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {

  constructor(private http: HttpClient) { }

  login(Username: string, PasswordUtente: string): Observable<RisToken> {
    let headerCustom = new HttpHeaders();
    headerCustom.set('Content-Type', 'application/json')

    let invio = {
      Username,
      PasswordUtente
    }

    return this.http.post<any>("https://localhost:7243/Utenti/login", invio, { headers: headerCustom });
  }
}
