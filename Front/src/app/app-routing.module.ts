import { AuthGuard } from './helpers/auth.guard';
import { ListCuestionariosComponent } from './components/home/list-cuestionarios/list-cuestionarios.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/home/login/login.component';
import { RegisterComponent } from './components/home/register/register.component';
import { WelcomeComponent } from './components/home/welcome/welcome.component';
import { IngresarNombreComponent } from './components/home/list-cuestionarios/ingresar-nombre/ingresar-nombre.component';
import { PreguntaComponent } from './components/home/list-cuestionarios/pregunta/pregunta.component';
import { RespuestaCuestionarioComponent } from './components/home/list-cuestionarios/respuesta-cuestionario/respuesta-cuestionario.component';

const routes: Routes = [
  {
    path:'',
    redirectTo: '/home',
    pathMatch:'full'
  },
  {
    path:'home',
    component: HomeComponent,
    children:[
      {
        path:'welcome',
        component: WelcomeComponent
      },
      {
        path:'register',
        component:RegisterComponent
      },
      {
        path:'login',
        component:LoginComponent
      },
      {
        path:'listCuestionarios',
        component:ListCuestionariosComponent,
        loadChildren:()=> import('./components/home/list-cuestionarios/list-cuestionarios.module')
                          .then(x=>x.ListCuestionariosModule)
                          
      },
      {
        path:'ingresarNombre',
        component:IngresarNombreComponent
      },
      {
        path:'pregunta',
        component:PreguntaComponent
      },
      {
        path:'respuetaCuestionario',
        component:RespuestaCuestionarioComponent
      },
      {
        path:'**',
        component:WelcomeComponent
      }
    
    ]
  },
  {
    path:'dashboard',
    component:DashboardComponent,
    canActivate: [AuthGuard],
    loadChildren:()=> import('./components/dashboard/dashboard.module')
                      .then(x=>x.DashboardModule)
  },
  {
    path:'**',
    redirectTo:'/home',
    pathMatch:'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
