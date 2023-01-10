import { ToastrService } from 'ngx-toastr';
import { CuestionarioService } from './../../../services/cuestionario.service';
import { Component, OnInit } from '@angular/core';
import { Cuestionario } from 'src/app/models/cuestionario';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-cuestionarios',
  templateUrl: './cuestionarios.component.html',
  styleUrls: ['./cuestionarios.component.css']
})
export class CuestionariosComponent implements OnInit {
  nombreUsuario: any;
  listCuestionario : Cuestionario[] = []
  loading :boolean = false;
  constructor(private loginService:LoginService,
              private cuestionario: CuestionarioService,
              private toastr:ToastrService) { }

  ngOnInit(): void {
    this.getNombreUsuario()
    this.getCuestionarios()
  }
  getNombreUsuario():void{
     this.nombreUsuario = this.loginService.getTokenDecode().sub
  }

  getCuestionarios():void{
    this.loading = true;
    this.cuestionario.getCuestionarios().subscribe(
      data=>{
        this.listCuestionario = data;
        this.loading = false;
      },error=>{
        console.error(error);
        this.loading = false;
      }
    )
  }
  deleteCuestionario(idCuestionario:number):void{
    if(confirm("Estas seguro que desea eliminar este cuestionario?"))
    {
      this.loading = true;
      this.cuestionario.deleteCuestionario(idCuestionario).subscribe(
      data=>{
        this.loading = false;
        this.toastr.success(data.message,"Cuestionario eliminado")
        this.getCuestionarios()
      },error=>{
        this.loading = false;
        this.toastr.error(error,"Ups..Ocurrio un error")
      });
    }
  }
}

