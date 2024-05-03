import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PersonaCreateComponent } from './components/persona-create/persona-create.component';
import { PersonaListComponent } from './components/persona-list/persona-list.component';

@NgModule({
  declarations: [
    AppComponent,
    PersonaCreateComponent,
    PersonaListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
