import { Component, ElementRef, ViewChild } from '@angular/core';
import { Messaggio } from '../../models/messaggio';
import { ActivatedRoute, Router } from '@angular/router';
import { ChatService } from '../../services/chat.service';
import { formatDate } from '@angular/common';
import { Stanza } from '../../models/stanza';
import { StanzaService } from '../../services/stanza.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrl: './chat.component.css'
})
export class ChatComponent {
  @ViewChild('scrollTarget')
  scrollTarget!: ElementRef;
  nomeUte:string |undefined;
  messaggi: Messaggio[] = new Array();
  nomeChat: string | undefined;
  messaggioInput: string | undefined;
  handleInterval: any;
  stanza: Stanza = new Stanza();
  constructor(
    private rottaAttiva: ActivatedRoute,
    private router: Router,
    private service: ChatService,
    private serviceStanza: StanzaService,
    private messaggioService: ChatService
  ) {}
  
  backToProfilo(): void {
    this.router.navigateByUrl('/profilo');
  }

  stampaMessaggi(nomeChat: string): void {
    this.service.stampaMessaggi(nomeChat).subscribe((risultato) => {
      this.messaggi = risultato.data;
    });
  }

  ngOnInit(): void {
    const email = localStorage.getItem("email");
    this.nomeUte = email !== null ? email : undefined;
    this.rottaAttiva.params.subscribe((parametro) => {
      this.nomeChat = parametro['roomName'];
    });
    
    this.handleInterval = setInterval(() => {
      this.stampaMessaggi(<string>this.nomeChat);
      this.dettaglio();
      console.log(this.stanza);
    },500);
    setTimeout(() => {
      this.scrollToBottom();
    },600);
  }

  scrollToTop(): void {
    window.scrollTo({ top: 0, behavior: 'smooth' });
  }
  scrollToBottom() {
    this.scrollTarget.nativeElement.scrollIntoView({ behavior: 'smooth', block: 'end', inline: 'nearest' });
  }
  dettaglio():void{
    if(this.nomeChat)
    this.serviceStanza.dettaglioStanza(this.nomeChat).subscribe((risultato)=>{
      this.stanza = risultato.data;
    })
  }
  inviaMessaggioComponent(): void {
    this.messaggioService.invio(<string>this.messaggioInput, <string>this.nomeUte, <string>this.nomeChat)
      .subscribe((risultato) => {
        this.messaggioInput = "";
      });
      setTimeout(() => {
        this.scrollToBottom();
      },600);
  }
  ngOnDestroy(): void {
    clearInterval(this.handleInterval); 
  }
}
