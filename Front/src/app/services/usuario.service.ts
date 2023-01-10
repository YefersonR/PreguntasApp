import { Injectable } from '@angular/core';
import { HttpClient} from "@angular/common/http";
import { Usuario } from '../models/usuario';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  myAppUrl:string;
  myApiUrl: string;

  constructor(private http:HttpClient) 
  {
    this.myAppUrl = environment.endPoint;
    this.myApiUrl = "api/usuario"
  }
  saveUser(usuario:Usuario): Observable<any>{
    return this.http.post(this.myAppUrl + this.myApiUrl,usuario)
  }

  changePassword(changePassword:any):Observable<any>{
    return this.http.put(this.myAppUrl + this.myApiUrl + "/changepassword",changePassword);
  }
}
