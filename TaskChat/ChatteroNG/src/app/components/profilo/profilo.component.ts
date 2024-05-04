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
  listaStanzeNuove: Stanza[] | undefined;
  nomeUte: string | undefined;
  handleInterval: any;
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
      this.stanzaService.recuperaStanzeNuove(this.nomeUte).subscribe((risultato) => {
        this.listaStanzeNuove = <Stanza[]>risultato.data;
      });
    }
  }
  enterChat(roomName: string): void {
    if(this.nomeUte){
      this.stanzaService.aggiungiUtente(roomName,this.nomeUte).subscribe((risultato) => {
        if (risultato.status == 'SUCCESS') alert(risultato.data);
        else alert('ERRORE');
      });
    } 
    this.router.navigateByUrl(`/chat/${roomName}`);
   
  }
  exitChat(roomName: string): void {
    if(this.nomeUte){
      this.stanzaService.rimuoviUtente(roomName,this.nomeUte).subscribe((risultato) => {
        if (risultato.status == 'SUCCESS') alert(risultato.data);
        else alert('ERRORE');
      });
    } 
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
    if(localStorage.getItem("email")){
      this.stanzaService.creaGlobal();
    }
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
