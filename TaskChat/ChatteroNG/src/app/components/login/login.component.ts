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
  constructor(private service: AuthService, private router: Router) {}

  register():void{
    this.router.navigateByUrl(`/register`);
  }
  clicca():void{
    alert("Trojan INCOMING!!!")
  }
  verifica(): void {
    this.obj.use = this.user;
    this.obj.pas = this.pass;
  
    // Controllo se i campi sono vuoti
    if (this.obj.use == "" || this.obj.pas == "") {
      alert("Inserisci tutti i campi");
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
      } else {
        // Se il login non ha successo, mostra un messaggio di errore
        Swal.fire('Errore!', 'Credenziali non valide.', 'error');
      }
    }, (error) => {
      // In caso di errore nella chiamata al servizio
      Swal.fire('Errore!', 'Credenziali non valide.', 'error');
    });
  }

  
  
}
