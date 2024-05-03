import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UtentiService } from '../../services/utenti.service';
import { ProfiloService } from '../../services/profilo.service';

@Component({
  selector: 'app-profilo',
  templateUrl: './profilo.component.html',
  styleUrl: './profilo.component.css',
})
export class ProfiloComponent {
  datiUtente: string | undefined;

  constructor(
    private router: Router,
    private serviceProfilo: ProfiloService,
    private serviceUtente: UtentiService
  ) {
    if (!localStorage.getItem('ilToken')) router.navigateByUrl('/login');
  }

  ngOnInit(): void {
    this.serviceProfilo.recuperaProfilo().subscribe((risultato) => {
      this.datiUtente = <string>risultato.data;
    });
  }
}
