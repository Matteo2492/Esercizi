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

  rip():void{
    alert("Ca**i tua")
  }
  sordi():void{
    alert("VENDETTA VERA NON FINIRO' IN GALERA!")
  }
  register():void{
    this.router.navigateByUrl(`/register`);
  }
  verifica(): void {
    this.obj.use = this.user;
    this.obj.pas = this.pass;
    if(this.obj.use == "" ||this.obj.pas == "" ){
      alert("Inserisci tutti i campi");
      return;
    }
    this.service.login(this.obj).subscribe((risultato) => {
      if (risultato.token) {
        localStorage.setItem('ilToken', risultato.token);
        localStorage.setItem('email', this.user);
        this.router.navigateByUrl('/profilo');
      }
    });
  }
}
