import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { Cuestionario } from './../../../../../models/cuestionario';
import { Pregunta } from './../../../../../models/pregunta';
import { CuestionarioService } from './../../../../../services/cuestionario.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-paso-dos',
  templateUrl: './paso-dos.component.html',
  styleUrls: ['./paso-dos.component.css']
})
export class PasoDosComponent implements OnInit {
  tituloCuestionario:string = "";
  descripcionCuestionario:string = "";
  listadoPreguntas: Pregunta[] = [];
  loading:boolean = false;
  constructor(
    private cuestionarioService:CuestionarioService,
    private router:Router,
    private toastr:ToastrService
    ) { }

  ngOnInit(): void {
    this.tituloCuestionario= this.cuestionarioService.tituloCuestionario;
    this.descripcionCuestionario = this.cuestionarioService.descripcionCuestionario;
  }

  guardarPregunta(pregunta:Pregunta):void{
    this.listadoPreguntas.push(pregunta)
  }
  eliminarPregunta(indice:number):void{
    this.listadoPreguntas.splice(indice,1)
  }
  guardarCuestionario():void{
    const cuestionario:Cuestionario = {
      nombre:this.tituloCuestionario,
      descripcion:this.descripcionCuestionario,
      preguntas : this.listadoPreguntas,

    } 
    this.loading = true;
    this.cuestionarioService.guardarCuestionario(cuestionario).subscribe(data=>{
      this.loading = false;
      this.toastr.success("El cuestionario fue registrado con exito","Cuestionario guardado");
      this.router.navigate(["/dashboard"])
    },error=>{
      this.loading = false;
      this.toastr.error("Ocurrio un error al enviar el formulario","Error")
      console.error(error);
    })
  }

}
