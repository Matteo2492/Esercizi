import { Component } from '@angular/core';
import { Persona } from '../../models/persona';
import { PersonaServiceService } from '../../services/persona-service.service';

@Component({
  selector: 'app-persona-create',
  templateUrl: './persona-create.component.html',
  styleUrl: './persona-create.component.css',
})
export class PersonaCreateComponent {
  codice: string | undefined;
  nome: string | undefined;

  constructor(private service: PersonaServiceService) {}

  salvaPersona() {
    let per = new Persona(this.codice, this.nome);
    this.service.inserisciPersona(per);
  }
}
