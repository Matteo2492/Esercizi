import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'ang_09_Ristorante';

  isLoggato: boolean = false;

  constructor(private router: Router) {
    if (localStorage.getItem('ilToken')) this.isLoggato = true;
  }

  logout() {
    localStorage.removeItem('ilToken');
    this.isLoggato = false;
    this.router.navigateByUrl('/');
  }
}
