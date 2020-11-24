import { Component, OnInit } from '@angular/core';
//import{Consumer} from 'src/models/Consumer.model';
import {Registerservice} from 'src/services/registerservice';
//import {NgForm} from '@angular/forms';

@Component({
  selector: 'app-consumer',
  templateUrl: './consumer.component.html',
  styleUrls: ['./consumer.component.css']
})
export class ConsumerComponent implements OnInit {
  bank:string[]=["Indian Bank","HDFC Bank","Canara Bank","State Bank of India","Punjab National Bank"]

  constructor(private regservice:Registerservice) { }

  ngOnInit(){
  }
  consumer:any={};
  result;
  err;
  onSubmit(){
   debugger;
   this.regservice.Adduser(this.consumer).subscribe((data)=>{this.result=data;
  console.log(this.result); window.alert(this.result) });

  }
  /*onSubmit(){
    debugger;
    this.regservice.Adduser(this.consumer).subscribe((data)=>{this.result=data;(error)=>{console.log(error);this.err=error.error.Message;console.log(this.err)}
   console.log(this.result); window.alert(this.result) });
 
   }*/

}
