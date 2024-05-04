import { Component } from '@angular/core';
import { Messaggio } from '../../models/messaggio';
import { ActivatedRoute, Router } from '@angular/router';
import { ChatService } from '../../services/chat.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrl: './chat.component.css'
})
export class ChatComponent {

  nomeUte:string |undefined;
  messaggi: Messaggio[] = new Array();
  nomeChat: string | undefined;
  messaggioInput: string | undefined;

  constructor(
    private rottaAttiva: ActivatedRoute,
    private router: Router,
    private service: ChatService,
    private messaggioService: ChatService
  ) {}
  
  backToProfilo(): void {
    this.router.navigateByUrl('/profilo');
  }

  stampaMessaggi(nomeChat: string): void {
    this.service.stampaMessaggi(nomeChat).subscribe((risultato) => {
      this.messaggi = risultato.data;
      console.log(risultato.data)
    });
  }

  ngOnInit(): void {
    const email = localStorage.getItem("email");
    this.nomeUte = email !== null ? email : undefined;
    this.rottaAttiva.params.subscribe((parametro) => {
      this.nomeChat = parametro['roomName'];
    });

    this.stampaMessaggi(<string>this.nomeChat);
  }

  inviaMessaggioComponent(): void {
    this.messaggioService.invio(<string>this.messaggioInput,<string>this.nomeUte,<string>this.nomeChat).subscribe((risultato) => {
        console.log(risultato.status);
      });
      
    location.replace('/chat/' + this.nomeChat);
  }
}
