import { Respuesta } from './../../../../../../models/respuesta';
import { ToastrService } from 'ngx-toastr';
import { Pregunta } from './../../../../../../models/pregunta';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormArray } from '@angular/forms';

@Component({
  selector: 'app-nueva-pregunta',
  templateUrl: './nueva-pregunta.component.html',
  styleUrls: ['./nueva-pregunta.component.css']
})
export class NuevaPreguntaComponent implements OnInit {
  nuevaPregunta : FormGroup;
  pregunta:Pregunta;
  resCorrecta = 0;
  @Output() enviarPregunta = new EventEmitter<Pregunta>();
  constructor(private fb:FormBuilder,
              private toastr:ToastrService) 
  {
    this.nuevaPregunta = fb.group({
      titulo:['',Validators.required],
      respuestas: this.fb.array([

      ])
    })

   
  }

  ngOnInit(): void {
    this.generarRespuestas()
  }

  get getRespuestas() : FormArray{
    return this.nuevaPregunta.get('respuestas') as FormArray;
  }

  addRespuestas():void{
    this.getRespuestas.push(this.fb.group({
      descripcion:['',Validators.required],
      resCorrecta :0
    }));
  }
  generarRespuestas():void{
    this.addRespuestas()
    this.addRespuestas()
  }
  eliminarRespuesta(indice:number):void{
    if(this.getRespuestas.length === 2){
      this.toastr.error("El cuestionario debe tener 2 respuestas como minimo","Error");
    }
    else{
      this.getRespuestas.removeAt(indice);
    }
  }
  asignarRespuesta(indice:number):void{
    this.resCorrecta = indice
  }
  agregarPregunta():void{
    const descripcionPregunta = this.nuevaPregunta.get('titulo')?.value 
    const respuestas = this.nuevaPregunta.get('respuestas')?.value

    const arrayRespuesta: Respuesta[] = []

    respuestas.forEach((element : any,index:number) => {
      const respuesta : Respuesta =  new Respuesta(this.resCorrecta == index,element.descripcion)
      arrayRespuesta.push(respuesta)
    });
    this.pregunta = new Pregunta(descripcionPregunta,arrayRespuesta)
    
    this.enviarPregunta.emit(this.pregunta)
    this.reset() 
  }
  reset():void{
    this.resCorrecta = 0;
    this.nuevaPregunta.reset();
    this.getRespuestas.clear();
    this.generarRespuestas();
  }

}
