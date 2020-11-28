import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import {Passwordservice} from 'src/services/passwordservice';
import {ForgotPassword} from 'src/models/password.model';
import { MustMatch } from '../MustMatch';
@Component({
  selector: 'app-forgotpassword',
  templateUrl: './forgotpassword.component.html',
  styleUrls: ['./forgotpassword.component.css']
})
export class ForgotpasswordComponent implements OnInit {
  forgotpassword:ForgotPassword = new ForgotPassword();
  forgotForm: FormGroup;
  submitted = false;
  isValidEmailId: boolean = false;
  errorMsg;
  emailId:string;
  constructor(private fb: FormBuilder, private router: Router,private passwordservice:Passwordservice) {}
  

  ngOnInit():void {
    this.forgotForm = this.fb.group({
      password: ['', [Validators.required, Validators.minLength(6)]],
     confirmPassword: ['', Validators.required],
      OTP: ['', [Validators.required, Validators.minLength(6)]]
  },{ validator: MustMatch('password', 'confirmPassword') }
  );
}
get f() { return this.forgotForm.controls; }

VerifyEmail() {
this.passwordservice.ForgotPassword(this.emailId).subscribe((response: any) => {
if (response == "Success") {
this.isValidEmailId = true;
this.errorMsg = '';
}
else {
this.errorMsg = 'Invalid User';
}
});
}
ChangePassword(model) {
this.submitted = true;
if (this.forgotForm.invalid) {
return;
}
model.Email = this.emailId;
this.passwordservice.ChangePassword(model).subscribe((response: any) => {
if (response == "Success") {
alert("Password changed Successfully.");
this.router.navigate(['login']);
}
else {
this.errorMsg = response;
}
});
}

  

}
