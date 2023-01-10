import { Router } from '@angular/router';
import { RespuestaCuestionarioService } from 'src/app/services/respuesta-cuestionario.service';
import { Cuestionario } from './../../../../models/cuestionario';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-respuesta-cuestionario',
  templateUrl: './respuesta-cuestionario.component.html',
  styleUrls: ['./respuesta-cuestionario.component.css']
})
export class RespuestaCuestionarioComponent implements OnInit {
  cuestionario:Cuestionario;
  respuestaUsuario:number[]=[];
  constructor(private respuestaCuestionario:RespuestaCuestionarioService,
              private router:Router
  )
  { }

  ngOnInit(): void {
    if(this.respuestaCuestionario.idCuestionario == null){
      this.router.navigate(['/home/listCuestionarios'])
    }
    else{
      this.cuestionario = this.respuestaCuestionario.cuestionario;
      this.respuestaUsuario = this.respuestaCuestionario.respuesta;
    }
  }
  


}
