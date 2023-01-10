import { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder,Validators} from '@angular/forms'
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Usuario } from 'src/app/models/usuario';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  register:FormGroup;
  loading = false;

  constructor(private fb:FormBuilder,
              private usuarioService:UsuarioService,
              private route:Router,
              private toastr:ToastrService) {
    this.register = this.fb.group({
      usuario:['',Validators.required],
      password:['',[Validators.required,Validators.minLength(4)]],
      confirmPassword:['']
    },{validators:this.checkPassword})}

  ngOnInit(): void {
  }
  registerUser():void{
    const usuario: Usuario = {
      nombreUsuario : this.register.value.usuario,
      password: this.register.value.password 
    }
    this.loading = true
    this.usuarioService.saveUser(usuario).subscribe(data=>{
      this.toastr.success("El usuario fue creado correctamente","Usuario Registrado!");
      this.route.navigate(['/home/login'])
      this.loading = false
    }, error=>{ 
      this.loading = false
      this.register.reset()
      this.toastr.error(error.error.message,"Error de registro!")
    });
  }
  checkPassword(group:FormGroup):any{
    const pass = group.controls['password'].value;
    const confirmPass = group.controls['confirmPassword'].value;
    return pass == confirmPass ? null :{notSame:true}
  }
}
