import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ProfiloService } from '../../services/profilo.service';
import { UtenteService } from '../../services/utente.service';
import { Stanza } from '../../models/stanza';
import { StanzaService } from '../../services/stanza.service';

@Component({
  selector: 'app-profilo',
  templateUrl: './profilo.component.html',
  styleUrl: './profilo.component.css'
})
export class ProfiloComponent {
  listaStanzeCreate: Stanza[] | undefined;
  listaStanzeP: Stanza[] | undefined;
  nomeUte: string | undefined;
  handleInterval: any;
  datcre: Date | undefined;
  formattedDatcre: string | undefined;
  
  nomesta : string | undefined;
  descsta : string | undefined;
  stanza: Stanza | undefined;
  
  constructor(
    private router: Router,
    private serviceProfilo: ProfiloService,
    private serviceUtente: UtenteService,
    private stanzaService: StanzaService
  ) {
    if (!localStorage.getItem('ilToken')) router.navigateByUrl('/login');
  }

  stampa(): void {
    if(this.nomeUte !== null){
      this.stanzaService.recuperaStanzePerUtente(this.nomeUte).subscribe((risultato) => {
        this.listaStanzeCreate = <Stanza[]>risultato.data;
      });
      this.stanzaService.recuperaStanzeP(this.nomeUte).subscribe((risultato) => {
        this.listaStanzeP = <Stanza[]>risultato.data;
      });
    }
  }
  enterChat(roomName: string): void {
    this.router.navigateByUrl(`/chat/${roomName}`);
  }
  creaStanza():void{
    this.stanza = new Stanza();
    if (this.stanza && this.nomeUte) {
      this.stanza.nomSta = this.nomesta;
      this.stanza.desc = this.descsta;
      this.stanza.cre = this.nomeUte;
    }
    this.stanzaService.creaStanza(this.stanza).subscribe((risultato) => {
      if (risultato.status == 'SUCCESS') alert(risultato.data);
      else alert('ERRORE');
    });
  }
  eliminaStanza(nomesta:string):void{
    this.stanzaService.eliminaStanza(nomesta).subscribe((risultato) => {
      if (risultato.status == 'SUCCESS') alert(risultato.data);
      else alert('ERRORE');
    });
  }
  ngOnInit(): void {
    const email = localStorage.getItem("email");
    this.nomeUte = email !== null ? email : undefined;
    this.serviceProfilo.recuperaProfilo().subscribe((risultato) => {
      this.nomeUte = risultato.data;
      this.stampa();
    });  
    this.handleInterval = setInterval(() => {
      this.stampa();
    },1000);
  }
  ngOnDestroy(): void {

    clearInterval(this.handleInterval); 
  }
}
