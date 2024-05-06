import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Risposta } from '../models/risposta';
import { Observable } from 'rxjs';
import { Prodotti } from '../models/prodotti';

@Injectable({
  providedIn: 'root',
})
export class ProdottiService {
  base_url: string = 'https://localhost:7243/Prodotti';

  constructor(private http: HttpClient) {}

  recuperaTuttiNonFiltrati(): Observable<Risposta> {
    return this.http.get<Risposta>(`${this.base_url}/tutti`);
  }

  eliminaProdotto(varCodice: string): Observable<Risposta> {
    return this.http.delete<Risposta>(`${this.base_url}/elimina/${varCodice}`);
  }

  inserisciProdotto(objProd: Prodotti): Observable<Risposta> {
    let headerCustom = new HttpHeaders();
    headerCustom.set('Content-Type', 'application/json');

    return this.http.post<Risposta>(`${this.base_url}/inserisci`, objProd, {
      headers: headerCustom,
    });
  }

  recuperaProdotto(varCodice: string): Observable<Risposta> {
    return this.http.get<Risposta>(`${this.base_url}/${varCodice}`);
  }

  modificaProdotto(objProd: Prodotti): Observable<Risposta> {
    let headerCustom = new HttpHeaders();
    headerCustom.set('Content-Type', 'application/json');

    return this.http.put<Risposta>(
      `${this.base_url}/modifica/${objProd.cod}`,
      objProd,
      { headers: headerCustom }
    );
  }
}
