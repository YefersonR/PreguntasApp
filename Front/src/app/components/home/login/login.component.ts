import { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder, Validators} from '@angular/forms' 
import {Usuario} from "../../../models/usuario"
import {ToastrService} from 'ngx-toastr'
import {Router} from '@angular/router'
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  login:FormGroup;
  loading = false;
  
  constructor(private fb:FormBuilder,
              private toastr: ToastrService,
              private router:Router,
              private loginService:LoginService ) { 
    this.login = this.fb.group({
      usuario:['',Validators.required],
      password:['',Validators.required]
    });

  }

  ngOnInit(): void {
  }

  log(){
    
    const usuario: Usuario = {
      nombreUsuario:this.login.value.usuario,
      password:this.login.value.password
    }    
    this.loading = true;
    
    this.loginService.login(usuario).subscribe(data=>{
      this.loading = false;
      this.loginService.setLocalStorage(data.token)
      this.router.navigate(['/dashboard'])
    },error=>{
      this.loading = false;
      this.login.reset();
      this.toastr.error(error.error.message,"Error al iniciar session")

    });
  }


}
