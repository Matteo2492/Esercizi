import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ProfiloService } from '../../services/profilo.service';
import { Stanza } from '../../models/stanza';
import { StanzaService } from '../../services/stanza.service';
import { ChatService } from '../../services/chat.service';
import Swal from 'sweetalert2'
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
  nomesta: string | undefined;
  descsta: string | undefined;
  stanza: Stanza | undefined;
  constructor(
    private router: Router,
    private serviceProfilo: ProfiloService,
    private serviceMsg: ChatService,
    private stanzaService: StanzaService
  ) {
    if (!localStorage.getItem('ilToken')) router.navigateByUrl('/login');
  }

  stampa(): void {
    if (this.nomeUte !== null) {
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
    if (this.nomeUte) {
      Swal.fire({
        title: roomName,
        text: `Vuoi entrare nella chat?`,
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: 'Sì',
        denyButtonText: 'No',
        customClass: {
          actions: 'my-actions',
          cancelButton: 'order-1 right-gap',
          confirmButton: 'order-2',
          denyButton: 'order-3',
        },
      }).then((result) => {
        if (result.isConfirmed && this.nomeUte) {
          this.stanzaService.aggiungiUtente(roomName, this.nomeUte).subscribe((risultato) => {
            if (risultato.status == 'SUCCESS') {
              Swal.fire('Benvenuto nella chat!', '', 'success').then(() => {
                this.router.navigateByUrl(`/chat/${roomName}`);
              });
            } else {
              Swal.fire('Errore!', 'Impossibile entrare nella chat.', 'error');
            }
          });
        } else if (result.isDenied) {
          Swal.fire('Entrata annullata', '', 'info');
        }
      });
    }
  }
  partecipa(roomName: string): void {
    this.router.navigateByUrl(`/chat/${roomName}`);
  }
  exitChat(roomName: string): void {
    if (this.nomeUte) {
      Swal.fire({
        title: roomName,
        text: `Vuoi uscire dalla chat?`,
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: 'Sì',
        denyButtonText: 'No',
        customClass: {
          actions: 'my-actions',
          cancelButton: 'order-1 right-gap',
          confirmButton: 'order-2',
          denyButton: 'order-3',
        },
      }).then((result) => {
        if (result.isConfirmed && this.nomeUte) {
          this.stanzaService.rimuoviUtente(roomName, this.nomeUte).subscribe((risultato) => {
            if (risultato.status == 'SUCCESS') {
              // Se la rimozione dell'utente ha successo, mostra un messaggio di successo
              Swal.fire('Hai lasciato la chat!', '', 'success');
            } else {
              // Se c'è un errore nella rimozione dell'utente, mostra un messaggio di errore
              Swal.fire('Errore!', 'Impossibile uscire dalla chat.', 'error');
            }
          });
        } else if (result.isDenied) {
          // Se l'utente rifiuta di uscire dalla chat, mostra un messaggio informativo
          Swal.fire('Uscita annullata', '', 'info');
        }
      });
    }
  }

  creaStanza(): void {
    this.stanza = new Stanza();
    if (this.stanza && this.nomeUte) {
      this.stanza.nomSta = this.nomesta;
      this.stanza.desc = this.descsta;
      this.stanza.cre = this.nomeUte;
    }
    this.stanzaService.creaStanza(this.stanza).subscribe({
      next: (risultato) => {
        if (risultato.status === 'SUCCESS') {
          Swal.fire({
            icon: 'success',
            title: 'Success',
            text: 'Stanza creata con successo!'
          });
        } else {
          Swal.fire({
            icon: 'error',
            title: 'Error',
            text: risultato.data
          });
        }
      },
      error: (error) => {
        Swal.fire({
          icon: 'error',
          title: 'Error',
          text: 'Errore nella creazione della stanza.'
        });
      }
    });
  }
  eliminaStanza(nomesta: string): void {
    Swal.fire({
      title: 'Sicuro di voler eliminare la stanza?',
      showDenyButton: true,
      showCancelButton: true,
      confirmButtonText: 'Yes',
      denyButtonText: 'No',
      customClass: {
        actions: 'my-actions',
        cancelButton: 'order-1 right-gap',
        confirmButton: 'order-2',
        denyButton: 'order-3',
      },
    }).then((result) => {
      if (result.isConfirmed) {
        this.stanzaService.eliminaStanza(nomesta).subscribe((risultato) => {
          if (risultato.status == 'SUCCESS') {
            Swal.fire('Stanza eliminata!', '', 'success');
          } else {
            Swal.fire('Errore!', 'Impossibile eliminare la stanza.', 'error');
          }
        });
      } else if (result.isDenied) {
        Swal.fire('Eliminazione annullata', '', 'info');
      }
    });
  }

  ngOnInit(): void {
    const email = localStorage.getItem("email");
    this.nomeUte = email !== null ? email : undefined;
    if(!this.stanzaService.recuperaStanzePerUtente("JESUS")){
      this.stanzaService.creaGlobal().subscribe(()=>{
        this.stampa();
      })
    }
    this.serviceProfilo.recuperaProfilo().subscribe((risultato) => {
      this.nomeUte = risultato.data;
      this.stampa();
    });
    this.handleInterval = setInterval(() => {
      this.stampa();
    }, 1000);
  }
  ngOnDestroy(): void {

    clearInterval(this.handleInterval);
  }


}
