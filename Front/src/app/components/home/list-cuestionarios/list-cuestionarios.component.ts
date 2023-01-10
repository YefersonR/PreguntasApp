import { ToastrService } from 'ngx-toastr';
import { CuestionarioService } from './../../../services/cuestionario.service';
import { Component, OnInit } from '@angular/core';
import { Cuestionario } from 'src/app/models/cuestionario';
import { Router } from '@angular/router';
import { RespuestaCuestionarioService } from 'src/app/services/respuesta-cuestionario.service';

@Component({
  selector: 'app-list-cuestionarios',
  templateUrl: './list-cuestionarios.component.html',
  styleUrls: ['./list-cuestionarios.component.css']
})
export class ListCuestionariosComponent implements OnInit {
  listCuestionario:Cuestionario[]=[]
  loading=false;
  constructor(private cuestionarioService:CuestionarioService,
              private toastr:ToastrService,
              private router:Router,
              private respuestaCuestionario:RespuestaCuestionarioService
              ) 
  {
    
  }

  ngOnInit(): void {
    this.getListCuestionario()
  }
  getListCuestionario():void{
    this.loading = true;
    this.cuestionarioService.getListCuestiorio().subscribe(
      data=>{
        this.loading = false;
        this.listCuestionario = data
      },
      error=>{
        this.loading = false;
        console.error(error)
        this.toastr.error("Ha ocurrido un error",'Error');        
      }
      )
  }
  ingresarNombre(idCuestionario:number):void{
    this.respuestaCuestionario.idCuestionario = idCuestionario
    this.router.navigate(['/home/ingresarNombre']);      
  }
}
