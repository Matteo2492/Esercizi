import { Component, ElementRef, ViewChild } from '@angular/core';
import { Messaggio } from '../../models/messaggio';
import { ActivatedRoute, Router } from '@angular/router';
import { ChatService } from '../../services/chat.service';
import { Stanza } from '../../models/stanza';
import { StanzaService } from '../../services/stanza.service';
import Swal from 'sweetalert2';

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
  eliminaMsg(nome: string | undefined, orario: Date | undefined): void {
    if (nome && orario) {
      Swal.fire({
        title: 'Conferma eliminazione',
        text: 'Sei sicuro di voler eliminare questo messaggio?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sì, elimina',
        cancelButtonText: 'Annulla',
        customClass: {
          confirmButton: 'btn btn-danger',
          cancelButton: 'btn btn-secondary'
        }
      }).then((result) => {
        if (result.isConfirmed) {
          this.messaggioService.eliminaMsg(nome, orario).subscribe((risultato) => {
            this.messaggi = risultato.data;
            Swal.fire('Messaggio eliminato', '', 'success');
          });
        }
      });
    }
    setTimeout(() => {
      this.scrollToBottom();
    }, 600);
  }
  aggiungiMembro(nuovoMembro: string): void {
    if (this.nomeChat) {
        this.serviceStanza.aggiungiUtente( this.nomeChat,nuovoMembro).subscribe((risultato) => {
            // In caso di successo, mostra una notifica con SweetAlert2
            Swal.fire({
                icon: 'success',
                title: 'Membro aggiunto con successo!',
                text: `Il membro ${nuovoMembro} è stato aggiunto alla chat.`,
                showConfirmButton: false,
                timer: 2000 // Chiude automaticamente la notifica dopo 2 secondi
            });
        }, (error) => {
            // In caso di errore, mostra una notifica di errore con SweetAlert2
            Swal.fire({
                icon: 'error',
                title: 'Errore!',
                text: 'Si è verificato un errore durante l\'aggiunta del membro alla chat. Si prega di riprovare più tardi.',
                confirmButtonText: 'OK'
            });
        });
    } else {
        // Se manca il nome della chat, mostra una notifica di avviso con SweetAlert2
        Swal.fire({
            icon: 'warning',
            title: 'Attenzione!',
            text: 'Si prega di fornire il nome della chat prima di aggiungere un membro.',
            confirmButtonText: 'OK'
        });
    }
    setTimeout(() => {
      this.scrollToBottom();
      this.dettaglio();
    }, 600);
  }
  rimuovi(partecipante:string):void{
    if (this.nomeChat) {
      this.serviceStanza.rimuoviUtente( this.nomeChat,partecipante).subscribe((risultato) => {
          // In caso di successo, mostra una notifica con SweetAlert2
          Swal.fire({
              icon: 'success',
              title: 'Membro rimosso con successo!',
              text: `Il membro ${partecipante} è stato rimosso alla chat.`,
              showConfirmButton: false,
              timer: 2000 // Chiude automaticamente la notifica dopo 2 secondi
          });
      }, (error) => {
          // In caso di errore, mostra una notifica di errore con SweetAlert2
          Swal.fire({
              icon: 'error',
              title: 'Errore!',
              text: 'Si è verificato un errore durante l\'eliminazione del membro alla chat. Si prega di riprovare più tardi.',
              confirmButtonText: 'OK'
          });
      });
  } else {
      // Se manca il nome della chat, mostra una notifica di avviso con SweetAlert2
      Swal.fire({
          icon: 'warning',
          title: 'Attenzione!',
          text: 'Si prega di fornire il nome della chat prima di aggiungere un membro.',
          confirmButtonText: 'OK'
      });
    }
    setTimeout(() => {
      this.scrollToBottom();
      this.dettaglio();
    }, 600);
  }
  ngOnInit(): void {
    const email = localStorage.getItem("email");
    this.nomeUte = email !== null ? email : undefined;
    this.rottaAttiva.params.subscribe((parametro) => {
      this.nomeChat = parametro['roomName'];
    });
    this.dettaglio();
    this.handleInterval = setInterval(() => {
      this.stampaMessaggi(<string>this.nomeChat);
      
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
