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
  ) { }

  login(): void {
    this.router.navigateByUrl(`/login`);
  }
  clicca(): void {
    Swal.fire({
      imageUrl: 'https://wallpapers-clan.com/wp-content/uploads/2022/08/meme-gif-pfp-1.gif',
      imageAlt: 'Custom image',
      confirmButtonText: 'Cool!',
      confirmButtonColor: '#3085d6',
      background: '#f3f3f3',
      customClass: {
        popup: 'my-custom-popup-class',
        title: 'my-custom-title-class',
        confirmButton: 'my-custom-confirm-button-class'
      },
    });
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
