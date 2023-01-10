import { ToastrService } from 'ngx-toastr';
import { RespuestaCuestionario } from 'src/app/models/respuestaCuestionario';
import { RespuestaCuestionarioService } from 'src/app/services/respuesta-cuestionario.service';
import { ActivatedRoute} from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-estadisticas',
  templateUrl: './estadisticas.component.html',
  styleUrls: ['./estadisticas.component.css']
})
export class EstadisticasComponent implements OnInit {
  idCuestionario:number;
  loading = false;
  listRespuestaCuestionario:RespuestaCuestionario[]=[]
  constructor(private router:ActivatedRoute,
              private respuestaCuestionario:RespuestaCuestionarioService,
              private toastR:ToastrService
  ) 
  { 
    this.idCuestionario = +router.snapshot.paramMap.get('id')!;
  }

  ngOnInit(): void {
    this.getListCuestionario();
  }
  getListCuestionario():void{
    this.loading = true;
    this.respuestaCuestionario.getListCuestionarioRespuesta(this.idCuestionario).subscribe(data=>{
    this.loading = false;
    this.listRespuestaCuestionario = data
    },
    error=>{
      this.loading = false
      console.error(error);
    });

  }
  deleteRespuesta(cuestionarioRespuesta:number):void{
    this.loading = true;
    this.respuestaCuestionario.deleteCuestionarioRespuesta(cuestionarioRespuesta).subscribe(data=>{
      this.loading = false;
      this.toastR.success("La respuesta fue eliminada con exito","Respuesta Eliminada")      
    },error=>{
      this.loading = false;
      console.error(error);
      this.toastR.error("Occurrio un error al borrar la respuest","Error")      

    });
  }

}
