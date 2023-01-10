import { RespuestaCuestionarioDetalles } from './../../../../../models/respuestaCuestionarioDetalle';
import { Cuestionario } from 'src/app/models/cuestionario';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RespuestaCuestionarioService } from 'src/app/services/respuesta-cuestionario.service';

@Component({
  selector: 'app-detalle-respuesta',
  templateUrl: './detalle-respuesta.component.html',
  styleUrls: ['./detalle-respuesta.component.css']
})
export class DetalleRespuestaComponent implements OnInit {
  idCuestionario:number;
  loading = false;
  cuestionario:Cuestionario;
  respuestas:RespuestaCuestionarioDetalles[]=[]
  constructor(private router:ActivatedRoute,
              private respuestaCuestionario:RespuestaCuestionarioService
  )
  {
    this.idCuestionario = +router.snapshot.paramMap.get('id')!;

  }

  ngOnInit(): void {
    this.getCuestionario()
  }
  getCuestionario():void{
    this.loading = true;
    this.respuestaCuestionario.getCuestionarioRespuesta(this.idCuestionario).subscribe(data=>{
      this.loading = false;
      this.cuestionario = data.cuestionario
      this.respuestas = data.respuestas
    },
    error=>{
      this.loading = false
      console.error(error);
    });

  }
}
