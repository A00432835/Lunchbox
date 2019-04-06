import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {NgbPaginationModule, NgbAlertModule} from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    
    NgbPaginationModule,
    NgbAlertModule,
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  
  bootstrap: [AppComponent]
})
export class AppModule { }
