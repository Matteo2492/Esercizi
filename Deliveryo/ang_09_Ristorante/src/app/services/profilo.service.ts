import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Risposta } from '../components/risposta';

@Injectable({
  providedIn: 'root',
})
export class ProfiloService {
  constructor(private http: HttpClient) {}

  recuperaProfilo(): Observable<Risposta> {
    let contenutoToken = localStorage.getItem('ilToken');
    let headerCustom = new HttpHeaders({
      Authorization: `Bearer ${contenutoToken}`,
    });

    return this.http.get<Risposta>(
      'https://localhost:7198/Utente/profiloutente/',
      { headers: headerCustom }
    );
  }
}
