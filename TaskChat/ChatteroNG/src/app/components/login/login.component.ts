import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Utente } from '../../models/utente';
import { AuthService } from '../../services/auth.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  obj: Utente = new Utente();
  user: string = '';
  pass: string = '';
  constructor(private service: AuthService, private router: Router) { }

  register(): void {
    this.router.navigateByUrl(`/register`);
  }
  clicca(): void {
    Swal.fire({
      imageUrl: 'https://gifdb.com/images/high/one-punch-man-funny-saitama-1x47t196vc3bodhj.gif',
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
  verifica(): void {
    this.obj.use = this.user;
    this.obj.pas = this.pass;

    // Controllo se i campi sono vuoti
    if (this.obj.use == "" || this.obj.pas == "") {
      Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Inserisci tutti i campi!',
      });
      return;
    }

    Swal.fire({
      title: 'Verifica in corso',
      text: 'Attendere prego...',
      allowOutsideClick: false,
      didOpen: () => {
        Swal.showLoading();
      }
    });

    // Chiamata al servizio per il login
    this.service.login(this.obj).subscribe((risultato) => {
      // Dopo aver ricevuto la risposta dal servizio
      if (risultato.token) {
        // Se il login ha successo, salva il token e l'email nell'localStorage e reindirizza alla pagina del profilo
        localStorage.setItem('ilToken', risultato.token);
        localStorage.setItem('email', this.user);
        Swal.fire('Accesso effettuato!', '', 'success').then(() => {
          this.router.navigateByUrl('/profilo');
        });
      }
    }, (error) => {
      // In caso di errore nella chiamata al servizio
      Swal.fire('Errore!', 'Credenziali non valide.', 'error');
    });
  }
}
