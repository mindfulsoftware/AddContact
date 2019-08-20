import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';

import { ContactComponent } from './contact/contact.component';
import { ContactService } from './contact/contact.service';
import { routeParts } from './constants';

const routes: Routes = [
  {path: '', redirectTo: `${routeParts.contact}/1`, pathMatch: 'full' },
  {path: `${routeParts.contact}/:${routeParts.idParam}`, component: ContactComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    ContactComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [
    ContactService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
