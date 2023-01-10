import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {
  changePassword : FormGroup;
  loading =false 
  constructor(private fb:FormBuilder,
              private usuarioService:UsuarioService,
              private toastr:ToastrService,
              private router:Router) {
    this.changePassword = this.fb.group({
      actualPassword: ['',Validators.required],
      newPassword:['',[Validators.minLength(4),Validators.required]],
      confirmPassword:['',Validators.required]
    },{validators:this.checkPassword})

   }

  ngOnInit(): void {
  }
  checkPassword(group:FormGroup): any{
    const pass = group.controls['newPassword'].value;
    const confirm = group.controls['confirmPassword'].value;
    return pass === confirm ? null : {notSame:true};
  }

  savePassword():void{
    this.loading = true
    const changePassword: any ={
      actualPassword: this.changePassword.value.actualPassword,
      newPassword : this.changePassword.value.newPassword
    }
    this.usuarioService.changePassword(changePassword).subscribe(data=>{
      this.loading = false
      this.router.navigate(["/dashboard"])
      this.toastr.info(data.message,"Contrasena cambiada con exito!")
    }, error=>{
      this.loading = false
      this.toastr.error(error.error.message,"Algo ha salido mal!")      
    })
  }
}
