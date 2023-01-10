import { Cuestionario } from './../models/cuestionario';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CuestionarioService {
  tituloCuestionario:string = "";
  descripcionCuestionario:string = "";

  myAppUrl:string;
  myApiUrl:string;
  constructor(private httpclient:HttpClient) { 
    this.myAppUrl = environment.endPoint;
    this.myApiUrl= "api/cuestionario/"

  }
  guardarCuestionario(cuestionario:Cuestionario):Observable<any>{
    return this.httpclient.post(this.myAppUrl + this.myApiUrl,cuestionario)
  }
  
  getCuestionarios():Observable<any>{
    return this.httpclient.get(this.myAppUrl + this.myApiUrl + 'GetCuestionariosByUser')
  }
  
  deleteCuestionario(idCuestionario:number):Observable<any>{
    return this.httpclient.delete(this.myAppUrl + this.myApiUrl + idCuestionario)
  }
  getCuestionarioById(idCuestionario:number):Observable<any>{
    return this.httpclient.get(this.myAppUrl + this.myApiUrl + idCuestionario)
  }
  getListCuestiorio():Observable<any>{
    return this.httpclient.get(this.myAppUrl + this.myApiUrl + 'GetListCuestionario')
  }
}
