import { Component } from '@angular/core';
import { Utente } from '../../models/utente';
import { UtenteService } from '../../services/utente.service';
import { StanzaService } from '../../services/stanza.service';
import { Router } from '@angular/router';
import { Messaggio } from '../../models/messaggio';
import { Stanza } from '../../models/stanza';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  user: string = '';
  pass: string = '';

  elencoMsg: Messaggio[] = new Array();
  elencoStanze: Stanza[] = new Array();
  handleInterval: any;

  constructor(
    private service: UtenteService,
    private serviceRistorante: StanzaService,
    private router: Router
  ) {}

  login():void{
    this.router.navigateByUrl(`/login`);
  }
  clicca():void{
    alert("Pew Pew. Sei morto.")
  }
  inserimento(): void {
    let utente = new Utente();
    utente.use = this.user;
    utente.pas = this.pass;
    if (utente.use !== '' && utente.pas !== '') {
      this.service.register(utente).subscribe((risultato) => {
        if (risultato.status === 'SUCCESS') {
          Swal.fire({
            icon: 'success',
            title: 'Registrazione avvenuta con successo!',
            text: risultato.data
          });
        } else {
          Swal.fire({
            icon: 'error',
            title: 'Errore',
            text: 'Si è verificato un errore durante la registrazione: ' + risultato.data
          });
        }
      }, (error) => {
        Swal.fire({
          icon: 'error',
          title: 'Errore',
          text: 'Si è verificato un errore durante la registrazione.'
        });
      });
    } else {
      Swal.fire({
        icon: 'warning',
        title: 'Attenzione!',
        text: 'Inserisci tutti i campi.'
      });
    }
  }
}
