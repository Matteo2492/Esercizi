import { Component, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { Utente } from '../../models/utente';
import { UtentiService } from '../../services/utenti.service';
import { RistoranteService } from '../../services/ristorante.service';
import { Ristorante } from '../../models/ristorante';
import { Piatto } from '../../models/piatto';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
})
export class RegisterComponent {
  name: string = '';
  user: string = '';
  pass: string = '';

  elenco: Ristorante[] = new Array();
  elencoPiatti: Piatto[] = new Array();
  handleInterval: any;

  constructor(
    private service: UtentiService,
    private serviceRistorante: RistoranteService,
    private router: Router
  ) {}

  stampa(): void {
    this.serviceRistorante.recuperaRistoranti().subscribe((risultato) => {
      this.elenco = <Ristorante[]>risultato.data;
      console.log(this.elenco);
    });
  }
  mostraMenu(codiceRistorante: string, ristoranteNom:string): void {
    this.serviceRistorante.recuperaPiatti(codiceRistorante).subscribe((risultato)=>{
      this.elencoPiatti = <Piatto[]>risultato.data;
      let nom: string | undefined;
      let des: string | undefined;
      let pre: number | undefined;
      let qua: number | undefined;
      this.elencoPiatti.forEach(element => {
        nom = element.nom;
        des = element.des;
        pre = element.pre;
        qua = element.qua;
      });
      alert(`MENU del ristorante ${ristoranteNom}\nNome piatto: ${nom}\n${des}\nPrezzo: ${pre}\nQuantita: ${qua}\n`);
    })
  }
  ngOnInit(): void {
    // this.handleInterval = setInterval(() => {
    //   //Associo l'handle dell'interval alla variabile (per il successivo clearinterval)
    //   this.stampa();
    // }, 1000);
    this.stampa();
    console.log(this.elenco);
  }

  ngOnDestroy(): void {
    // console.log("Distrutto Lista Component")
    clearInterval(this.handleInterval); //Eliminazione dell'interval tramite il suo handle
  }
  inserimento(): void {
    let utente = new Utente();
    utente.nom = this.name;
    utente.ema = this.user;
    utente.pas = this.pass;
    if (utente.ema != '' && utente.pas != '' && utente.nom != '') {
      this.service.register(utente).subscribe((risultato) => {
        if (risultato.status == 'SUCCESS') alert(risultato.data);
        else alert('ERRORE');
      });
    } else {
      alert('Inserisci tutti i campi');
    }
  }
}
