import { Observable } from 'rxjs';
import { RespuestaCuestionario } from './../models/respuestaCuestionario';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Cuestionario } from '../models/cuestionario';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RespuestaCuestionarioService {
  myAppUrl:string;
  myApiUrl:string;
  
  
  nombreParticipante:string;
  idCuestionario:number;
  respuesta:number[]=[]
  cuestionario:Cuestionario;
  constructor(private httpClient:HttpClient
              )
  { 
    this.myAppUrl = environment.endPoint;
    this.myApiUrl = 'api/respuestacuestionario/'
  }
  guardarRespuestaCuestionario(respuestaCuestionario:RespuestaCuestionario):Observable<any>{
    return this.httpClient.post(this.myAppUrl + this.myApiUrl,respuestaCuestionario);
  }
  getListCuestionarioRespuesta(idCuestionario:number):Observable<any>{
    return this.httpClient.get(this.myAppUrl + this.myApiUrl + idCuestionario)
  }
  getCuestionarioRespuesta(idCuestionario:number):Observable<any>{
    return this.httpClient.get(this.myAppUrl + this.myApiUrl + 'GetRespuestaCuestionarioById/' + idCuestionario)
  }
  
  deleteCuestionarioRespuesta(idCuestionario:number):Observable<any>{
    return this.httpClient.delete(this.myAppUrl + this.myApiUrl + idCuestionario)
  }
}
