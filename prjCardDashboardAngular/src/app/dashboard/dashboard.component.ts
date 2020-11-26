import { Component, OnInit } from '@angular/core';
import {Cardservice} from 'src/services/cardservice';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
   carddetails:any=[];
  creditdetails:any=[];
  purchasedetails:any=[];
  transactiondetails:any=[];
  
  constructor(private cardservice:Cardservice) { }

  ngOnInit(){
   this.getCardinfo();
   this.getCreditinfo();
   this.getPurchaseinfo();
   this.getTransactioninfo();
  }
  username="Harshit";
  //calling carddetails from card service
  getCardinfo()
  {
    this.cardservice.getCarddetails(this.username).subscribe((data)=>{this.carddetails=data;console.log(this.carddetails)});
    //console.log(this.carddetails);
  }
 //calling creditdetails from card service
 getCreditinfo()
  {
    this.cardservice.getCredit(this.username).subscribe((data)=>{this.creditdetails=data;console.table(this.creditdetails)});
   
  }
  //calling purchasedetails from card service
   getPurchaseinfo()
  {
    this.cardservice.getProductPurchase(this.username).subscribe((data)=>{this.purchasedetails=data;console.log(this.purchasedetails)});
    //console.log(this.purchasedetails);

  }
  //calling transactiondetails from card service
  getTransactioninfo()
  {
    //debugger;
    this.cardservice.getTransaction(this.username).subscribe((data)=>{this.transactiondetails=data;console.table(this.transactiondetails)});
    console.log(this.transactiondetails);

  }


}
