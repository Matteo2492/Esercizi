import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthServiceService } from '../../services/auth-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  
  user: string = "";
  pass: string = "";

  constructor(private service: AuthServiceService, private router: Router){

  }

  verifica():void {

    this.service.login(this.user, this.pass).subscribe(risultato => {
      if(risultato.token){
        localStorage.setItem("ilToken", risultato.token)
        this.router.navigateByUrl("/profilo");
      }
    })

  }
}
