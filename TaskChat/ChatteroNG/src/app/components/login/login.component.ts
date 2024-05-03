import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Utente } from '../../models/utente';
import { AuthService } from '../../services/auth.service';

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

  verifica(): void {
    this.obj.use = this.user;
    this.obj.pas = this.pass;
    
    this.service.login(this.obj).subscribe((risultato) => {
      if (risultato.token) {
        localStorage.setItem('ilToken', risultato.token);
        localStorage.setItem('email', this.user);
        this.router.navigateByUrl('/profilo');
      }
    });
  }
}
