import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'ChatteroNG';

  isLoggato: boolean = false;

  constructor(private router: Router) {
    if (localStorage.getItem('ilToken')) {
      this.isLoggato = true;
      this.router.navigate(['/profilo']); // Reindirizza alla rotta "profilo"
    }
  }
  logout() {
    localStorage.removeItem('ilToken');
    this.isLoggato = false;
    this.router.navigateByUrl('/');
  }
}
