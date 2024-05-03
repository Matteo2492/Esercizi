import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RisToken } from '../models/ris-token';
import { Utente } from '../models/utente';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient) {}

  login(obj: Utente): Observable<RisToken> {
    let headerCustom = new HttpHeaders();
    headerCustom.set('Content-Type', 'application/json');
    return this.http.post<any>('https://localhost:7260/Auth/login', obj, {
      headers: headerCustom,
    });
  }
}
