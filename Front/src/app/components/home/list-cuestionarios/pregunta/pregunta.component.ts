import { RespuestaCuestionarioDetalles } from './../../../../models/respuestaCuestionarioDetalle';
import { Respuesta } from './../../../../models/respuesta';
import { Pregunta } from './../../../../models/pregunta';
import { Router } from '@angular/router';
import { CuestionarioService } from './../../../../services/cuestionario.service';
import { RespuestaCuestionarioService } from './../../../../services/respuesta-cuestionario.service';
import { Component, OnInit } from '@angular/core';
import { RespuestaCuestionario } from 'src/app/models/respuestaCuestionario';

@Component({
  selector: 'app-pregunta',
  templateUrl: './pregunta.component.html',
  styleUrls: ['./pregunta.component.css']
})
export class PreguntaComponent implements OnInit {
  idCuestionario:number;
  listPreguntas:Pregunta[]=[]
  loading=false;
  resConfirmada=false;
  opcionSeleccionada:any;
  index:number = 0;
  idResSeleccionada:number;

  listRespuestasDetalle:RespuestaCuestionarioDetalles[] =[]

  constructor(private respuestaCuestionario:RespuestaCuestionarioService,
              private cuestionarioService:CuestionarioService,
              private router:Router
  ) 
  { }

  ngOnInit(): void {
    this.idCuestionario = this.respuestaCuestionario.idCuestionario;
    if(this.idCuestionario == null){
      this.router.navigate(['/home/listCuestionarios'])
      return;
    }
    this.getCuestionario();
    this.respuestaCuestionario.respuesta = [];
  }
  getCuestionario():void{
    this.loading = true;
    this.cuestionarioService.getCuestionarioById(this.idCuestionario).subscribe(
      data=>{
        this.loading = false;
        this.listPreguntas = data.preguntas
        this.respuestaCuestionario.cuestionario = data;
      }
    );

  }
  obtenerPregunta():string{
    return this.listPreguntas[this.index].descripcion
  }
  getIndex():number{
    return this.index;
  }
  seleccionarRespuesta(respuesta:Respuesta):void{
    this.opcionSeleccionada = respuesta;
    this.resConfirmada = true;
    this.idResSeleccionada = respuesta.id!;
  }
  addClassOption(respuesta:Respuesta): string{
    if(respuesta === this.opcionSeleccionada){
      return 'active text-light'
    }
    return '';
  }
  siguiente():void{
    this.respuestaCuestionario.respuesta.push(this.idResSeleccionada)

    const detalleRespuesta:RespuestaCuestionarioDetalles={
      respuestaId:this.idResSeleccionada,
      RespuestaCuestionarioId:this.respuestaCuestionario.idCuestionario
    }
    this.listRespuestasDetalle.push(detalleRespuesta);
    this.resConfirmada = false;
    this.index++;
    this.idResSeleccionada = 0;
    if(this.index == this.listPreguntas.length)
    {
      this.guardarRespuestaCuestionario()
    }
  }
  
  guardarRespuestaCuestionario():void{
    const resCuestionario: RespuestaCuestionario={
      CuestionarioId : this.respuestaCuestionario.idCuestionario,
      NombreParticipante: this.respuestaCuestionario.nombreParticipante,
      RespuestaDetalles: this.listRespuestasDetalle
    };
    this.loading=true;
    console.log(resCuestionario)
    this.respuestaCuestionario.guardarRespuestaCuestionario(resCuestionario).subscribe(
      data=>{
        this.loading=false;
        this.router.navigate(['/home/respuetaCuestionario']); 
      },error=>{
        this.loading=false;
        console.error(error);
      }
    )
  }

}
