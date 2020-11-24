import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ConsumerComponent } from './consumer/consumer.component';
import {FormsModule} from '@angular/forms';
import {Registerservice} from 'src/services/registerservice';
import {MustMatchDirective} from './PasswordMatching/must-match.directive';
@NgModule({
  declarations: [
    AppComponent,
    ConsumerComponent,
    MustMatchDirective
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,FormsModule
  ],
  providers: [Registerservice],
  bootstrap: [AppComponent]
})
export class AppModule { }
