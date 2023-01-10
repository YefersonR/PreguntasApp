import { CuestionarioService } from './../../../../services/cuestionario.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-cuestionario',
  templateUrl: './cuestionario.component.html',
  styleUrls: ['./cuestionario.component.css']
})
export class CuestionarioComponent implements OnInit {
  id:number;
  loading = false;
  cuestionario:any={};
  constructor(private cuestionarioService:CuestionarioService,
              private eRoute:ActivatedRoute) 
  {
    this.id = +this.eRoute.snapshot.paramMap.get('id')!
  }

  ngOnInit(): void {
    this.getCuestionarioById(this.id);
  }

  getCuestionarioById(idCuestionario:number):void{
    this.loading = true;    
    this.cuestionarioService.getCuestionarioById(idCuestionario).subscribe(
      data=>{
        this.cuestionario = data
        this.loading = false;    
      },error=>{

        this.loading = false;    
      }
    )
  }
}
