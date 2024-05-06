import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ProfiloService } from '../../services/profilo.service';
import { Prodotti } from '../../models/prodotti';
import { ProdottiService } from '../../services/prodotti.service';

@Component({
  selector: 'app-profilo',
  templateUrl: './profilo.component.html',
  styleUrl: './profilo.component.css',
})
export class ProfiloComponent {
  datiUtente: string | undefined;
  elenco: Prodotti[] = new Array();
  handleInterval: any;
  visualizzaModifica: boolean = false;

  private cod: string | undefined;
  nom: string | undefined;
  cat: string | undefined;
  des: string | undefined;
  pre: number | undefined;
  qua: number | undefined;

  constructor(
    private router: Router,
    private serviceprofilo: ProfiloService,
    private serviceprodotti: ProdottiService
  ) {
    if (!localStorage.getItem('ilToken')) router.navigateByUrl('/login');
  }

  stampa(): void {
    this.serviceprodotti.recuperaTuttiNonFiltrati().subscribe((risultato) => {
      if (risultato && Array.isArray(risultato)) {
        this.elenco = risultato as Prodotti[];
      }
    });
  }
  ngOnInit(): void {
    this.serviceprofilo.recuperaProfilo().subscribe((risultato) => {
      this.datiUtente = risultato.data;
    });
    this.handleInterval = setInterval(() => {
      //Associo l'handle dell'interval alla variabile (per il successivo clearinterval)
      this.stampa();
    }, 1000);
  }
  ngOnDestroy(): void {
    // console.log("Distrutto Lista Component")
    clearInterval(this.handleInterval); //Eliminazione dell'interval tramite il suo handle
  }
}
