import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Usuario } from '../models/usuario';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  myAppUrl:string;
  myApiUrl:string;
  constructor(private http:HttpClient) 
  {
    this.myAppUrl = environment.endPoint
    this.myApiUrl = "api/login"
  }
login(usuario:Usuario):Observable<any>{
  return this.http.post(this.myAppUrl + this.myApiUrl,usuario)
}

setLocalStorage(data:string):void{
  localStorage.setItem("token",data);
}

  
getTokenDecode():string{
  const helper = new JwtHelperService();
  const decodeToken = helper.decodeToken(localStorage.getItem("token") || "")
  return decodeToken;
}
  

  removeLocalStorage():void{
    localStorage.removeItem("token")
  }
  getToken():string | null{
    return localStorage.getItem("token")
  }


}
