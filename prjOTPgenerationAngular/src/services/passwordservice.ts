import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: "root" })

export class Passwordservice{

    constructor(private http:HttpClient){

    }
//Calling WebApi For Forgot Password
ForgotPassword(email){

return this.http.get('https://localhost:44391/api/OTP/VerifyEmail?email=' + email);

}
// Calling WebApi For Change Password
ChangePassword(model){

    return this.http.post('https://localhost:44391/api/OTP/ChangePassword', model);
}
}
