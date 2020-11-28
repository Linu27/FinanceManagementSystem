import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ForgotpasswordComponent } from './forgotpassword/forgotpassword.component';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import {Passwordservice} from 'src/services/passwordservice';
import {FormBuilder} from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    ForgotpasswordComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,FormsModule,ReactiveFormsModule
  ],
  providers: [Passwordservice,FormBuilder],
  bootstrap: [AppComponent]
})
export class AppModule { }
